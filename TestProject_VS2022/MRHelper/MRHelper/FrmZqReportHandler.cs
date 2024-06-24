using Magicodes.ExporterAndImporter.Excel.Utility;
using MRHelper.Entity;
using MRHelper.ExcelExportDTO;
using MRHelper.Utils;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing.Processors.Quantization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRHelper
{
    public partial class FrmZqReportHandler : Form
    {
        public FrmZqReportHandler()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名
                string[] str = new string[] { ".xlsx", ".xls" };
                if (!((IList)str).Contains(extension))
                {
                    MessageBox.Show("仅能上传 Excel 文件！");
                }
                else
                {
                    txtFile.Text = fileDialog.FileName;
                    var excelDataList = ReadExcel(txtFile.Text.Trim());

                    int c1 = excelDataList.Where(x => x.FreezeStatus == "冻结").Count();

                    var bankCash = CalcCashByBankAccountCode(excelDataList);

                    DueCashZero(bankCash, ref excelDataList);
                    DueCashGreaterThanZero(bankCash, ref excelDataList);

                    int c2 = excelDataList.Where(x => x.FreezeStatus == "冻结").Count();

                    DueCashLessThanZero(bankCash, ref excelDataList);

                    int c3 = excelDataList.Where(x => x.FreezeStatus == "冻结").Count();

                    // 导出
                    var fileUrl = ExportData(txtFile.Text.Trim(), ref excelDataList);
                }
            }
        }

        /// <summary>
        /// 读取 Excel 表内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<ZqReportEntity> ReadExcel(string filePath)
        {
            var importData = ExcelUtil.ImportExcel<ZqReportEntity>(filePath).Result;
            var list = importData.Data.ToList();
            if (list != null && list.Count > 0)
            {
                return list;
            }
            return null;
        }

        /// <summary>
        /// 按银行账号统计本期金额
        /// </summary>
        /// <param name="excelDataList"></param>
        private List<ZqReport4BankCashEntity> CalcCashByBankAccountCode(List<ZqReportEntity> excelDataList)
        {
            var bankCash = (from p in excelDataList
                            where (p.BankAccountCode != null && p.BankAccountCode.Length > 0)
                            group p by p.BankAccountCode into g
                            select new ZqReport4BankCashEntity
                            {
                                BankAccountCode = g.Key,
                                CashAll = g.Sum(p => p.Cash),
                                CashFs = g.Sum(p => p.Cash < 0 ? p.Cash : 0),
                            }).ToList<ZqReport4BankCashEntity>();

            return bankCash;
        }

        /// <summary>
        /// 处理 账期金额总额等于0时 的业务
        /// 该银行账号下的所有渠道信息标记为冻结
        /// </summary>
        /// <param name="bankCash"></param>
        /// <param name="excelDataList"></param>
        private void DueCashZero(List<ZqReport4BankCashEntity> bankCash, ref List<ZqReportEntity> excelDataList)
        {
            var list = bankCash.Where(x => x.CashAll == 0).ToList<ZqReport4BankCashEntity>();

            if (list.Count == 0) return;

            foreach (var item in list)
            {
                var orgList = excelDataList.Where(x => x.BankAccountCode == item.BankAccountCode);
                foreach (var orgItem in orgList)
                {
                    orgItem.FreezeType = 20;
                    orgItem.FreezeStatus = "冻结";
                    orgItem.FreezeReason = $"银行账号 [{orgItem.BankAccountCode}] 本期金额总额等于 0";
                }
            }
        }

        /// <summary>
        /// 处理 账期金额总额总额大于0且有负数 的业务
        /// 当该银行账号下的某一渠道的账期金额与负数总额相近，冻结其渠道
        /// 如果没有符合条件的单一渠道，将多个渠道的金额排列组合相加，找出跟负数总额相近的金额的组合的渠道，冻结
        /// 相近的意思是：
        /// 1. 金额大于负数总额
        /// 2. 金额减去负数总额的值最小的那个渠道（或者某些渠道之和）
        /// </summary>
        /// <param name="bankCash"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZero(List<ZqReport4BankCashEntity> bankCash, ref List<ZqReportEntity> excelDataList)
        {
            var list = bankCash.Where(x => x.CashAll > 0 && x.CashFsAbs > 0).ToList<ZqReport4BankCashEntity>();

            if (list.Count == 0) return;

            foreach (var item in list)
            {
                var orgData = excelDataList
                    .Where(x => x.BankAccountCode == item.BankAccountCode && x.Cash > item.CashFsAbs)
                    .OrderBy(x => x.Cash)
                    .FirstOrDefault();
                
                if (orgData == null)
                {
                    // 找到银行账号下面所有金额大于0的渠道信息
                    var orgList = excelDataList.Where(x => x.BankAccountCode == item.BankAccountCode && x.Cash > 0).OrderByDescending(x => x.Cash).ToList();
                    
                    /* 测试是否按照金额从小到大排序
                    StringBuilder sb = new StringBuilder(1024);
                    foreach (var org in orgList)
                    {
                        sb.AppendLine($"渠道编号 [{org.ChannelCode}]：{org.Cash}");
                    }
                    var ss = sb.ToString();
                    */

                    // 找到与银行账号负数金额相近的渠道信息冻结
                    ZqReport4CCCashEntity ccCashObj = FindChannel(orgList, item.BankAccountCode, item.CashFsAbs);
                    
                    string channelCodeStr = string.Join(",", ccCashObj.ChannelCodeList);
                    foreach (var channelCode in ccCashObj.ChannelCodeList)
                    {
                        var orgRealList = excelDataList.Where(x => x.BankAccountCode == ccCashObj.BankAccountCode && x.ChannelCode == channelCode);
                        foreach (var orgItem in orgRealList)
                        {
                            orgItem.FreezeType = 11;
                            orgItem.FreezeStatus = "冻结";
                            orgItem.FreezeReason = $"银行账号 [{orgItem.BankAccountCode}] 本期金额总额大于 0 且有负数，渠道组合 [{channelCodeStr}] 的金额是 [{ccCashObj.CCCash}]，与它的银行账号 [{ccCashObj.BankAccountCode}] 本期负数总额相近 [{item.CashFsAbs}]";
                        }
                    }
                }
                else
                {
                    orgData.FreezeType = 10;
                    orgData.FreezeStatus = "冻结";
                    orgData.FreezeReason = $"银行账号 [{orgData.BankAccountCode}] 本期金额总额大于 0 且有负数，渠道编码 [{orgData.ChannelCode}] 的金额是 [{orgData.Cash}], 与它的银行账号 [{orgData.BankAccountCode}] 本期负数总额相近 [{item.CashFsAbs}]";
                }
            }
        }

        /// <summary>
        /// 在 账期金额总额总额大于0且有负数 的渠道中，找出组合金额大于银行账号负数总额的渠道组合
        /// </summary>
        /// <param name="list"></param>
        /// <param name="bankAccountCode"></param>
        /// <param name="bankCashFs"></param>
        /// <returns></returns>
        private ZqReport4CCCashEntity FindChannel(List<ZqReportEntity> list, string bankAccountCode, decimal bankCashFs)
        {
            decimal preCash = 0m;
            decimal diffCash = 0m;
            ZqReport4CCCashEntity ccCashObj = new ZqReport4CCCashEntity();
            ccCashObj.BankAccountCode = bankAccountCode;

            foreach (var item in list)
            {
                decimal currCash = preCash + item.Cash;
                
                if (currCash > bankCashFs)
                {
                    diffCash = bankCashFs - preCash;
                    break;
                }
                else
                {
                    preCash = currCash;
                    ccCashObj.ChannelCodeList.Add(item.ChannelCode);
                }
            }

            if (diffCash == 0m)
            {
                // 如果循环下来，累加的金额都没当前银行账号的负数金额大，那么所有正数金额的渠道都要冻结
                ccCashObj.CCCash = preCash;
            } 
            else
            {
                // 找到金额比差异金额大的渠道列表，再从其中拿最小的那个渠道
                var obj = list.Where(x => x.Cash > diffCash).OrderBy(x => x.Cash).FirstOrDefault();
                decimal ccCash = preCash + obj.Cash;
                ccCashObj.ChannelCodeList.Add(obj.ChannelCode);
                ccCashObj.CCCash = ccCash;
            }
            
            return ccCashObj;
        }

        /// <summary>
        /// 处理 银行账期金额总额小于0 业务
        /// 1. 当前银行账号下的所有渠道信息冻结
        /// 2. 找出当前银行账号的银行账户名称下面的其它银行账号的所有金额大于0的渠道信息
        /// 2.1 排除掉已经被冻结的渠道
        /// 3. 冻结其它银行账号跟当前银行账号负数总额相近的渠道，条件：
        /// 3.1 其它银行账号的金额大于0且有负数
        /// </summary>
        /// <param name="bankCash"></param>
        /// <param name="excelDataList"></param>
        private void DueCashLessThanZero(List<ZqReport4BankCashEntity> bankCash, ref List<ZqReportEntity> excelDataList)
        {
            var list = bankCash.Where(x => x.CashAll < 0).ToList<ZqReport4BankCashEntity>();

            foreach (var item in list)
            {
                string bankAccountCode = item.BankAccountCode;
                string bankAccountName = string.Empty;
                decimal cashFsAbs = item.CashFsAbs; // 当前银行账号的负数总额
                decimal currCash = 0m;              // 当前银行账号下面所有金额大于 0 的渠道的金额总额
                decimal diffCash = 0m;              // 当前银行账号的负数总额和 cashFsAbs 的差异金额

                // 1. 当前银行账号下的所有金额小于等于 0 的 渠道信息冻结
                var orgList = excelDataList.Where(x => x.BankAccountCode == bankAccountCode);
                foreach (var orgItem in orgList)
                {
                    // 找出当前银行账号的银行账户名称
                    if (string.IsNullOrEmpty(bankAccountName)) bankAccountName = orgItem.BankAccountName;

                    // 当前银行账号下面所有金额大于 0 的渠道的金额总额累加
                    if (orgItem.Cash > 0) currCash += orgItem.Cash;

                    // 标记为冻结
                    orgItem.FreezeType = 30;
                    orgItem.FreezeStatus = "冻结";
                    orgItem.FreezeReason = $"银行账号 [{bankAccountCode}] 本期金额总额小于 0";
                }
                diffCash = cashFsAbs - currCash;

                // 2. 找出当前银行账号的银行账户名称下面的所有金额大于0的渠道，排除掉已经被冻结的
                var orgList2 = excelDataList.Where(x => x.BankAccountName == bankAccountName && x.Cash > 0 && x.FreezeStatus != "冻结").ToList();

                if (orgList2.Count == 0) return;

                // 3. 找到与银行账号负数金额（差异金额）相近的渠道信息冻结
                var orgData = orgList2
                    .Where(x => x.Cash > diffCash)
                    .OrderBy(x => x.Cash)
                    .FirstOrDefault();
                if (orgData == null)
                {
                    ZqReport4CCCashEntity ccCashObj = FindChannel(orgList2, bankAccountCode, diffCash);

                    string channelCodeStr = string.Join(",", ccCashObj.ChannelCodeList);
                    foreach (var channelCode in ccCashObj.ChannelCodeList)
                    {
                        var orgRealList = excelDataList.Where(x => x.BankAccountCode == ccCashObj.BankAccountCode && x.ChannelCode == channelCode);
                        foreach (var orgItem in orgRealList)
                        {
                            orgItem.FreezeType = 32;
                            orgItem.FreezeStatus = "冻结";
                            orgItem.FreezeReason = $"银行账号 [{bankAccountCode}] 本期金额总额小于 0，其银行账户名称 [{bankAccountName}] 的其他银行账号的渠道组合 [{channelCodeStr}] 的金额是 [{ccCashObj.CCCash}]，与其扣除后的负数总额相近 [{diffCash}]";
                        }
                    }
                }
                else
                {
                    orgData.FreezeType = 31;
                    orgData.FreezeStatus = "冻结";
                    orgData.FreezeReason = $"银行账号 [{bankAccountCode}] 本期金额总额小于 0，其银行账户名称 [{bankAccountName}] 的其他银行账号的渠道编码 [{orgData.ChannelCode}] 的金额是 [{orgData.Cash}], 与其本期扣除后的负数总额相近 [{diffCash}]";
                }
            }
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="excelDataList"></param>
        private string ExportData(string orgFilePath, ref List<ZqReportEntity> excelDataList)
        {
            var exportDto = new ZqReportExportDto(excelDataList);
            string savePath = Directory.GetParent(orgFilePath).FullName;
            string fileName = string.Format("{0}_处理后_{1}.xlsx", Path.GetFileNameWithoutExtension(orgFilePath), DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string filePath = Path.Combine(savePath, fileName);
            string templatePath = @"ExcelTemplate/ZqReportTemplate.xlsx";

            string fileUrl = ExcelUtil.ExportExcelByTemplate(exportDto, filePath, templatePath).Result;
            return fileUrl;
        }

    }
}
