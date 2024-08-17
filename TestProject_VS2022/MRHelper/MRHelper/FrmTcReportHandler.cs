using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MRHelper.Entity;
using MRHelper.ExcelExportDTO;
using MRHelper.Utils;
using MRHelper.Extensions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace MRHelper
{
    public partial class FrmTcReportHandler : Form
    {
        // 无效值，从外部文件获取
        private string[] invaildVal = null;

        // 声明 BackgroundWorker 对象
        private BackgroundWorker m_BackgroundWorker;

        public FrmTcReportHandler()
        {
            InitializeComponent();
            ReadTcFilter();

            m_BackgroundWorker = new BackgroundWorker();            // 实例化 BackgroundWorker 对象
            m_BackgroundWorker.WorkerReportsProgress = true;        // 设置可以通告进度
            m_BackgroundWorker.WorkerSupportsCancellation = false;  // 设置不可以取消

            // 声明 DoWork 事件
            m_BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);

            // 声明 ProgressChanged 事件
            m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);

            // 声明 RunWorkerCompleted 事件
            m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
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

                    // 如果后台线程空闲，则启动后台操作
                    if (!m_BackgroundWorker.IsBusy)
                    {
                        // 启动后台操作，触发 DoWork 事件
                        // 参数可传可不传，暂时没什么有什么作用
                        m_BackgroundWorker.RunWorkerAsync(this);
                    }
                }
            }
        }

        #region 业务处理

        /// <summary>
        /// 读取无效值
        /// </summary>
        private void ReadTcFilter()
        {
            string filePath = "TcFilter.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                invaildVal = content.Split(',');
            }
        }

        /// <summary>
        /// 读取 Excel 表内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<TcReportEntity> ReadExcel(string filePath)
        {
            var importData = ExcelUtil.ImportExcel<TcReportEntity>(filePath).Result;

            if (importData.Data == null)
            {
                MessageBox.Show(importData.Exception.Message);
            }
            else
            {
                var list = importData.Data.ToList();
                if (list != null && list.Count > 0)
                {
                    return list;
                }
            }
            return null;
        }

        /// <summary>
        /// 初始化原始 Excel 表格数据的 连锁冻结信息（冻结金额、剩余可冻结金额）
        /// </summary>
        /// <param name="excelDataList"></param>

        private void InitChainFreezeData(ref List<TcReportEntity> excelDataList)
        {
            int id = 0;
            foreach (var item in excelDataList)
            {
                id++;
                item.ID = id;
                item.ChainFreezeResult.FreezeCash = 0m;
                item.ChainFreezeResult.ReCanFreezeCash = item.Cash;
            }
        }

        #region 处理连锁分组业务需求
        /// <summary>
        /// 连锁分组
        /// </summary>
        /// <returns></returns>
        private List<TcReportGroupEntity> GroupChain(ref List<TcReportEntity> excelDataList)
        {
            var chainGroups =  (from p in excelDataList
                                where (p.Chain != null && p.Chain.Length > 0)
                                group p by p.Chain into g
                                select new TcReportGroupEntity 
                                {
                                    GroupKey = g.Key,
                                    CashAll = g.Sum(p => p.Cash),
                                    CashFs = g.Sum(p => p.Cash < 0 ? p.Cash : 0),
                                }).ToList<TcReportGroupEntity>();

            return chainGroups;
        }

        /// <summary>
        /// 处理连锁分组业务
        /// </summary>
        /// <param name="chainGroups">连锁分组</param>
        /// <param name="excelDataList"></param>
        private void HandleChain(List<TcReportGroupEntity> chainGroups, ref List<TcReportEntity> excelDataList)
        {
            foreach (var chain in chainGroups)
            {
                string chainName = chain.GroupKey;

                // 1. 如果是无效的连锁名称，跳过
                if (invaildVal.Contains(chainName)) continue;

                // 2. 获取当前连锁本期金额大于0的渠道，存储在正数渠道中
                List<TcReportEntity> ZsList = excelDataList.Where(x => x.Chain != null && x.Chain.Equals(chainName) && x.Cash > 0).OrderBy(x => x.Cash).ToList();

                // 3. 获取当前连锁本期金额小于0的渠道，存储在负数渠道中
                List<TcReportEntity> FsList = excelDataList.Where(x => x.Chain != null && x.Chain.Equals(chainName) && x.Cash <= 0).OrderBy(x => x.Cash).ToList();

                // 4. 如果当前连锁分组的本期金额的总值大于0
                if (chain.CashAll > 0)
                {
                    DueCashGreaterThanZero4Chain(ZsList, FsList, chain.CashFsAbs, ref excelDataList);
                }
                // 5. 如果当前连锁分组的本期金额的总值小于或等于0
                else
                {
                    DueCashLessThanOrEqualZero4Chain(ZsList, FsList, ref excelDataList);
                }
            }
        }

        /// <summary>
        /// 处理连锁分组的本期金额总值大于 0 的业务
        /// </summary>
        /// <param name="ZsList">连锁分组下的正数渠道</param>
        /// <param name="FsList">连锁分组下的负数渠道</param>
        /// <param name="groupFsAbs">连锁分组的负数金额总和绝对值</param>
        /// <param name="excelDataList">原始 Excel 文件数据</param>
        private void DueCashGreaterThanZero4Chain(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            TcReportEntity zsEntity = null;

            // 1. 遍历循环每一个正数渠道，计算对应渠道的本期金额的值
            foreach (var zsEntityItem in ZsList)
            {
                // 2. 当某一个正数渠道的本期金额的值大于当前分组负数金额的绝对值时，获取这个正数渠道，停止遍历
                if (zsEntityItem.Cash > groupFsAbs)
                {
                    zsEntity = zsEntityItem;
                    break;
                }
            }
            
            if (zsEntity != null)
            {
                DueCashGreaterThanZeroIfOneChanel4Chain(zsEntity, FsList, ref excelDataList);
            }
            else
            {
                DueCashGreaterThanZeroIfMulChanel4Chain(ZsList, FsList, groupFsAbs, ref excelDataList);
            }
        }

        /// <summary>
        /// 处理有某一个正数渠道的本期金额的的值大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="zsEntity">正数渠道</param>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfOneChanel4Chain(TcReportEntity zsEntity, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            decimal zsCash = zsEntity.Cash;
            StringBuilder zsFreezeReason = new StringBuilder(1024);
            zsFreezeReason.Append(zsEntity.Chain);

            // 1. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2. 跳过值为0的数据
                if (fsEntityItem.Cash == 0) continue;

                // 3. 获取对应负数渠道的本期金额的绝对值
                decimal fsCash = Math.Abs(fsEntityItem.Cash);

                // 4. 重新调整正数金额
                zsCash = zsCash - fsCash;

                // 5. 更新原始数据中当前连锁的相应的负数渠道的冻结信息
                var orgEntity4Fs = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity4Fs.FreezeType = 10;  // 连锁，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Fs.ChainFreezeResult.FreezeCash = fsCash;
                orgEntity4Fs.ChainFreezeResult.ReCanFreezeCash = 0;
                orgEntity4Fs.ChainFreezeResult.FreezeReason = $"{fsEntityItem.Chain} {zsEntity.ChannelCode} 冻结了 {fsCash}";

                zsFreezeReason.Append($" {fsEntityItem.ChannelCode} 冻结了 {fsCash}，");
            }

            // 6. 如果有冻结负数渠道，更新原始数据中当前连锁的相应的正数渠道的冻结信息
            if (zsEntity.Cash > zsCash)
            {
                zsFreezeReason.Length--; // 去掉最后一个中文逗号
                var orgEntity4Zs = excelDataList.FirstOrDefault(x => x.ID == zsEntity.ID);
                orgEntity4Zs.FreezeType = 10;  // 连锁，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Zs.ChainFreezeResult.FreezeCash = -(zsEntity.Cash - zsCash);
                orgEntity4Zs.ChainFreezeResult.ReCanFreezeCash = zsCash;
                orgEntity4Zs.ChainFreezeResult.FreezeReason = zsFreezeReason.ToString();
            }
        }

        /// <summary>
        /// 处理有多个正数渠道的本期金额的的值的总和大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfMulChanel4Chain(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            // 1. 获取大于分组的负数金额绝对值的多个正数渠道
            //    正数渠道按金额升序排序保证筛选出来的这些正数渠道的本期金额的和与负数金额绝对值的差值
            decimal zsCash = 0m;
            List<TcReportEntity> zsListSelected = new List<TcReportEntity>();
            foreach (var zsEntityItem in ZsList)
            {
                zsCash = zsCash + zsEntityItem.Cash;
                zsListSelected.Add(zsEntityItem);
                if (zsCash > groupFsAbs) break;
            }

            // 2. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2-1. 跳过值为0的数据
                if (fsEntityItem.Cash == 0) continue;

                // 2-2. 循环遍历上一步筛选出来的正数渠道
                decimal freezeCash = 0m;
                foreach (var zsEntityItem in zsListSelected)
                {
                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (zsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCashAbs = zsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.ChainFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCashAbs < fsCashAbs ? zsCashAbs : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.ChainFreezeResult.FreezeCash = zsEntityItem.ChainFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.ChainFreezeResult.ReCanFreezeCash = zsEntityItem.ChainFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.ChainFreezeResult.FreezeReason))
                    {
                        zsEntityItem.ChainFreezeResult.FreezeReason = $"{zsEntityItem.Chain} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.ChainFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.ChainFreezeResult.FreezeCash = fsEntityItem.ChainFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.ChainFreezeResult.ReCanFreezeCash = fsEntityItem.ChainFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.ChainFreezeResult.FreezeReason))
                    {
                        fsEntityItem.ChainFreezeResult.FreezeReason = $"{fsEntityItem.Chain} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.ChainFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-7. 如果负数渠道已经冻结完，跳出正数渠道的循环
                    if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in zsListSelected)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 11;  // 连锁，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.ChainFreezeResult.FreezeCash = zsEntityItem.ChainFreezeResult.FreezeCash;
                orgEntity.ChainFreezeResult.ReCanFreezeCash = zsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                orgEntity.ChainFreezeResult.FreezeReason = zsEntityItem.ChainFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.Cash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 11;  // 连锁，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.ChainFreezeResult.FreezeCash = fsEntityItem.ChainFreezeResult.FreezeCash;
                orgEntity.ChainFreezeResult.ReCanFreezeCash = fsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                orgEntity.ChainFreezeResult.FreezeReason = fsEntityItem.ChainFreezeResult.FreezeReason;
            }
        }

        /// <summary>
        /// 处理分组的本期金额总值小于或等于 0 的业务
        /// </summary>
        private void DueCashLessThanOrEqualZero4Chain(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            // 1. 循环遍历负数渠道
            foreach (var zsEntityItem in ZsList)
            {
                decimal freezeCash = 0m;

                // 2. 循环遍历负数渠道
                foreach (var fsEntityItem in FsList)
                {
                    // 2-1. 跳过值为0的数据
                    if (fsEntityItem.Cash == 0) continue;

                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCash = zsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.ChainFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCash < fsCashAbs ? zsCash : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.ChainFreezeResult.FreezeCash = zsEntityItem.ChainFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.ChainFreezeResult.ReCanFreezeCash = zsEntityItem.ChainFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.ChainFreezeResult.FreezeReason))
                    {
                        zsEntityItem.ChainFreezeResult.FreezeReason = $"{zsEntityItem.Chain} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.ChainFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.ChainFreezeResult.FreezeCash = fsEntityItem.ChainFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.ChainFreezeResult.ReCanFreezeCash = fsEntityItem.ChainFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.ChainFreezeResult.FreezeReason))
                    {
                        fsEntityItem.ChainFreezeResult.FreezeReason = $"{fsEntityItem.Chain} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.ChainFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 如果正数渠道的金额已经为 0，跳出负数渠道的循环
                    if (zsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in ZsList)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 12;  // 连锁，分组金额总额小于等于0
                orgEntity.ChainFreezeResult.FreezeCash = zsEntityItem.ChainFreezeResult.FreezeCash;
                orgEntity.ChainFreezeResult.ReCanFreezeCash = zsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                orgEntity.ChainFreezeResult.FreezeReason = zsEntityItem.ChainFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.Cash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 12;  // 连锁，分组金额总额小于等于0
                orgEntity.ChainFreezeResult.FreezeCash = fsEntityItem.ChainFreezeResult.FreezeCash;
                orgEntity.ChainFreezeResult.ReCanFreezeCash = fsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                orgEntity.ChainFreezeResult.FreezeReason = fsEntityItem.ChainFreezeResult.FreezeReason;
            }
        }
        #endregion

        /// <summary>
        /// 初始化原始 Excel 表格数据的法人冻结信息（剩余可冻结金额）
        /// 法人冻结信息的剩余可冻结金额的初始值等于连锁冻结信息的剩余可冻结金额
        /// </summary>
        /// <param name="excelDataList"></param>

        private void InitLegalFreezeData(ref List<TcReportEntity> excelDataList)
        {
            foreach (var item in excelDataList)
            {
                item.LegalFreezeResult.ReCanFreezeCash = item.ChainFreezeResult.ReCanFreezeCash;
            }
        }

        #region 处理法人分组业务需求
        /// <summary>
        /// 法人分组
        /// </summary>
        /// <returns></returns>
        private List<TcReportGroupEntity> GroupLegal(ref List<TcReportEntity> excelDataList)
        {
            var legalGroups = (from p in excelDataList
                               where (p.LegalerCode != null && p.LegalerCode.Length > 0 && p.ChainFreezeResult.ReCanFreezeCash != 0)
                               group p by p.LegalerCode into g
                               select new TcReportGroupEntity
                               {
                                   GroupKey = g.Key,
                                   CashAll = g.Sum(p => p.ChainFreezeResult.ReCanFreezeCash),
                                   CashFs = g.Sum(p => p.ChainFreezeResult.ReCanFreezeCash < 0 ? p.ChainFreezeResult.ReCanFreezeCash : 0),
                               }).ToList<TcReportGroupEntity>();

            return legalGroups;
        }

        /// <summary>
        /// 处理法人分组业务
        /// </summary>
        /// <param name="legalGroups"></param>
        /// <param name="excelDataList"></param>
        private void HandleLegal(List<TcReportGroupEntity> legalGroups, ref List<TcReportEntity> excelDataList)
        {
            foreach (var legal in legalGroups)
            {
                string legalName = legal.GroupKey;

                // 1. 如果是无效的法人身份证号，跳过
                if (invaildVal.Contains(legalName)) continue;

                // 2. 获取当前法人剩余可冻结金额大于0的渠道，存储在正数渠道中
                List<TcReportEntity> ZsList = excelDataList.Where(x => x.LegalerCode != null && x.LegalerCode.Equals(legalName) && x.ChainFreezeResult.ReCanFreezeCash > 0).OrderBy(x => x.ChainFreezeResult.ReCanFreezeCash).ToList();

                // 3. 获取当前法人剩余可冻结金额小于0的渠道，存储在负数渠道中
                List<TcReportEntity> FsList = excelDataList.Where(x => x.LegalerCode != null && x.LegalerCode.Equals(legalName) && x.ChainFreezeResult.ReCanFreezeCash < 0).OrderBy(x => x.ChainFreezeResult.ReCanFreezeCash).ToList();

                // 4. 如果当前连锁分组的本期金额的总值大于0
                if (legal.CashAll > 0)
                {
                    DueCashGreaterThanZero4Legal(ZsList, FsList, legal.CashFsAbs, ref excelDataList);
                }
                // 5. 如果当前连锁分组的本期金额的总值小于或等于0
                else
                {
                    DueCashLessThanOrEqualZero4Legal(ZsList, FsList, ref excelDataList);
                }
            }
        }

        /// <summary>
        /// 处理法人分组的剩余可冻结金额总值大于 0 的业务
        /// </summary>
        /// <param name="ZsList">法人分组下的正数渠道</param>
        /// <param name="FsList">法人分组下的负数渠道</param>
        /// <param name="groupFsAbs">法人分组的负数金额总和绝对值</param>
        /// <param name="excelDataList">原始 Excel 文件数据</param>
        private void DueCashGreaterThanZero4Legal(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            TcReportEntity zsEntity = null;

            // 1. 遍历循环每一个正数渠道，计算对应渠道的本期金额的值
            foreach (var zsEntityItem in ZsList)
            {
                // 2. 当某一个正数渠道的本期金额的值大于当前分组负数金额的绝对值时，获取这个正数渠道，停止遍历
                if (zsEntityItem.ChainFreezeResult.ReCanFreezeCash > groupFsAbs)
                {
                    zsEntity = zsEntityItem;
                    break;
                }
            }

            if (zsEntity != null)
            {
                DueCashGreaterThanZeroIfOneChanel4Legal(zsEntity, FsList, ref excelDataList);
            }
            else
            {
                DueCashGreaterThanZeroIfMulChanel4Legal(ZsList, FsList, groupFsAbs, ref excelDataList);
            }
        }

        /// <summary>
        /// 处理有某一个正数渠道的本期金额的的值大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="zsEntity">正数渠道</param>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfOneChanel4Legal(TcReportEntity zsEntity, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            decimal zsCash = zsEntity.ChainFreezeResult.ReCanFreezeCash;
            StringBuilder zsFreezeReason = new StringBuilder(1024);
            zsFreezeReason.Append(zsEntity.LegalerCode);

            // 1. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2. 跳过值为0的数据
                if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                // 3. 获取对应负数渠道的本期金额的绝对值
                decimal fsCash = Math.Abs(fsEntityItem.ChainFreezeResult.ReCanFreezeCash);

                // 4. 重新调整正数金额
                zsCash = zsCash - fsCash;

                // 5. 更新原始数据中当前法人的相应的负数渠道的冻结信息
                var orgEntity4Fs = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity4Fs.FreezeType = 20;  // 法人，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Fs.LegalFreezeResult.FreezeCash = fsCash;
                orgEntity4Fs.LegalFreezeResult.ReCanFreezeCash = 0;
                orgEntity4Fs.LegalFreezeResult.FreezeReason = $"{fsEntityItem.LegalerCode} {zsEntity.ChannelCode} 冻结了 {fsCash}";

                zsFreezeReason.Append($" {fsEntityItem.ChannelCode} 冻结了 {fsCash}，");
            }

            // 6. 如果有冻结负数渠道，更新原始数据中当前法人的相应的正数渠道的冻结信息
            if (zsEntity.ChainFreezeResult.ReCanFreezeCash > zsCash)
            {
                zsFreezeReason.Length--; // 去掉最后一个中文逗号
                var orgEntity4Zs = excelDataList.FirstOrDefault(x => x.ID == zsEntity.ID);
                orgEntity4Zs.FreezeType = 20;  // 法人，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Zs.LegalFreezeResult.FreezeCash = -(zsEntity.ChainFreezeResult.ReCanFreezeCash - zsCash);
                orgEntity4Zs.LegalFreezeResult.ReCanFreezeCash = zsCash;
                orgEntity4Zs.LegalFreezeResult.FreezeReason = zsFreezeReason.ToString();
            }
        }

        /// <summary>
        /// 处理有多个正数渠道的本期金额的的值的总和大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfMulChanel4Legal(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            // 1. 获取大于分组的负数金额绝对值的多个正数渠道
            //    正数渠道按金额升序排序保证筛选出来的这些正数渠道的本期金额的和与负数金额绝对值的差值
            decimal zsCash = 0m;
            List<TcReportEntity> zsListSelected = new List<TcReportEntity>();
            foreach (var zsEntityItem in ZsList)
            {
                zsCash = zsCash + zsEntityItem.ChainFreezeResult.ReCanFreezeCash;
                zsListSelected.Add(zsEntityItem);
                if (zsCash > groupFsAbs) break;
            }

            // 2. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2-1. 跳过值为0的数据
                if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                // 2-2. 循环遍历上一步筛选出来的正数渠道
                decimal freezeCash = 0m;
                //decimal fsCashAbs = Math.Abs(fsEntityItem.ChainFreezeResult.ReCanFreezeCash);
                foreach (var zsEntityItem in zsListSelected)
                {
                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (zsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCashAbs = zsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.LegalFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCashAbs < fsCashAbs ? zsCashAbs : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.LegalFreezeResult.FreezeCash = zsEntityItem.LegalFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.LegalFreezeResult.ReCanFreezeCash = zsEntityItem.LegalFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.LegalFreezeResult.FreezeReason))
                    {
                        zsEntityItem.LegalFreezeResult.FreezeReason = $"{zsEntityItem.LegalerCode} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.LegalFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.LegalFreezeResult.FreezeCash = fsEntityItem.LegalFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.LegalFreezeResult.ReCanFreezeCash = fsEntityItem.LegalFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.LegalFreezeResult.FreezeReason))
                    {
                        fsEntityItem.LegalFreezeResult.FreezeReason = $"{fsEntityItem.LegalerCode} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.LegalFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-7. 如果负数渠道已经冻结完，跳出正数渠道的循环
                    if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in zsListSelected)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 21;  // 法人，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.LegalFreezeResult.FreezeCash = zsEntityItem.LegalFreezeResult.FreezeCash;
                orgEntity.LegalFreezeResult.ReCanFreezeCash = zsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                orgEntity.LegalFreezeResult.FreezeReason = zsEntityItem.LegalFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 21;  // 法人，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.LegalFreezeResult.FreezeCash = fsEntityItem.LegalFreezeResult.FreezeCash;
                orgEntity.LegalFreezeResult.ReCanFreezeCash = fsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                orgEntity.LegalFreezeResult.FreezeReason = fsEntityItem.LegalFreezeResult.FreezeReason;
            }
        }

        /// <summary>
        /// 处理分组的本期金额总值小于或等于 0 的业务
        /// </summary>
        private void DueCashLessThanOrEqualZero4Legal(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            // 1. 循环遍历负数渠道
            foreach (var zsEntityItem in ZsList)
            {
                decimal freezeCash = 0m;

                // 2. 循环遍历负数渠道
                foreach (var fsEntityItem in FsList)
                {
                    // 2-1. 跳过值为0的数据
                    if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCash = zsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.LegalFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCash < fsCashAbs ? zsCash : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.LegalFreezeResult.FreezeCash = zsEntityItem.LegalFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.LegalFreezeResult.ReCanFreezeCash = zsEntityItem.LegalFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.LegalFreezeResult.FreezeReason))
                    {
                        zsEntityItem.LegalFreezeResult.FreezeReason = $"{zsEntityItem.LegalerCode} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.LegalFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.LegalFreezeResult.FreezeCash = fsEntityItem.LegalFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.LegalFreezeResult.ReCanFreezeCash = fsEntityItem.LegalFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.LegalFreezeResult.FreezeReason))
                    {
                        fsEntityItem.LegalFreezeResult.FreezeReason = $"{fsEntityItem.LegalerCode} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.LegalFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 如果正数渠道的金额已经为 0，跳出负数渠道的循环
                    if (zsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in ZsList)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 22;  // 法人，分组金额总额小于等于0
                orgEntity.LegalFreezeResult.FreezeCash = zsEntityItem.LegalFreezeResult.FreezeCash;
                orgEntity.LegalFreezeResult.ReCanFreezeCash = zsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                orgEntity.LegalFreezeResult.FreezeReason = zsEntityItem.LegalFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.ChainFreezeResult.ReCanFreezeCash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 22;  // 连锁，分组金额总额小于等于0
                orgEntity.LegalFreezeResult.FreezeCash = fsEntityItem.LegalFreezeResult.FreezeCash;
                orgEntity.LegalFreezeResult.ReCanFreezeCash = fsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                orgEntity.LegalFreezeResult.FreezeReason = fsEntityItem.LegalFreezeResult.FreezeReason;
            }
        }
        #endregion

        /// <summary>
        /// 初始化原始 Excel 表格数据的总公司冻结信息（剩余可冻结金额）
        /// 总公司冻结信息的剩余可冻结金额的初始值等于法人冻结信息的剩余可冻结金额
        /// </summary>
        /// <param name="excelDataList"></param>

        private void InitTopCompanyFreezeData(ref List<TcReportEntity> excelDataList)
        {
            foreach (var item in excelDataList)
            {
                item.TopCompanyFreezeResult.ReCanFreezeCash = item.LegalFreezeResult.ReCanFreezeCash;
            }
        }

        #region 处理总公司分组业务需求
        /// <summary>
        /// 总公司分组
        /// </summary>
        /// <returns></returns>
        private List<TcReportGroupEntity> GroupTopCompany(ref List<TcReportEntity> excelDataList)
        {
            var topcomGroups = (from p in excelDataList
                                where (p.TopCompany != null && p.TopCompany.Length > 0 && p.LegalFreezeResult.ReCanFreezeCash != 0)
                                group p by p.TopCompany into g
                                select new TcReportGroupEntity
                                {
                                    GroupKey = g.Key,
                                    CashAll = g.Sum(p => p.LegalFreezeResult.ReCanFreezeCash),
                                    CashFs = g.Sum(p => p.LegalFreezeResult.ReCanFreezeCash < 0 ? p.LegalFreezeResult.ReCanFreezeCash : 0),
                                }).ToList<TcReportGroupEntity>();

            return topcomGroups;
        }

        /// <summary>
        /// 处理总公司分组业务
        /// </summary>
        /// <param name="topcomGroups"></param>
        /// <param name="excelDataList"></param>
        private void HandleTopCompany(List<TcReportGroupEntity> topcomGroups, ref List<TcReportEntity> excelDataList)
        {
            foreach (var topCompany in topcomGroups)
            {
                string topcomName = topCompany.GroupKey;

                // 1. 如果是无效的总公司名称，跳过
                if (invaildVal.Contains(topcomName)) continue;

                // 2. 获取当前总公司剩余可冻结金额大于0的渠道，存储在正数渠道中
                List<TcReportEntity> ZsList = excelDataList.Where(x => x.TopCompany != null && x.TopCompany.Equals(topcomName) && x.LegalFreezeResult.ReCanFreezeCash > 0).OrderBy(x => x.LegalFreezeResult.ReCanFreezeCash).ToList();

                // 3. 获取当前总公司剩余可冻结金额小于0的渠道，存储在负数渠道中
                List<TcReportEntity> FsList = excelDataList.Where(x => x.TopCompany != null && x.TopCompany.Equals(topcomName) && x.LegalFreezeResult.ReCanFreezeCash < 0).OrderBy(x => x.LegalFreezeResult.ReCanFreezeCash).ToList();

                // 4. 如果当前连锁分组的本期金额的总值大于0
                if (topCompany.CashAll > 0)
                {
                    DueCashGreaterThanZero4TopCompany(ZsList, FsList, topCompany.CashFsAbs, ref excelDataList);
                }
                // 5. 如果当前连锁分组的本期金额的总值小于或等于0
                else
                {
                    DueCashLessThanOrEqualZero4TopCompany(ZsList, FsList, ref excelDataList);
                }
            }
        }

        /// <summary>
        /// 处理法人分组的剩余可冻结金额总值大于 0 的业务
        /// </summary>
        /// <param name="ZsList">法人分组下的正数渠道</param>
        /// <param name="FsList">法人分组下的负数渠道</param>
        /// <param name="groupFsAbs">法人分组的负数金额总和绝对值</param>
        /// <param name="excelDataList">原始 Excel 文件数据</param>
        private void DueCashGreaterThanZero4TopCompany(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            TcReportEntity zsEntity = null;

            // 1. 遍历循环每一个正数渠道，计算对应渠道的本期金额的值
            foreach (var zsEntityItem in ZsList)
            {
                // 2. 当某一个正数渠道的本期金额的值大于当前分组负数金额的绝对值时，获取这个正数渠道，停止遍历
                if (zsEntityItem.LegalFreezeResult.ReCanFreezeCash > groupFsAbs)
                {
                    zsEntity = zsEntityItem;
                    break;
                }
            }

            if (zsEntity != null)
            {
                DueCashGreaterThanZeroIfOneChanel4TopCompany(zsEntity, FsList, ref excelDataList);
            }
            else
            {
                DueCashGreaterThanZeroIfMulChanel4TopCompany(ZsList, FsList, groupFsAbs, ref excelDataList);
            }
        }

        /// <summary>
        /// 处理有某一个正数渠道的本期金额的的值大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="zsEntity">正数渠道</param>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfOneChanel4TopCompany(TcReportEntity zsEntity, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            decimal zsCash = zsEntity.LegalFreezeResult.ReCanFreezeCash;
            StringBuilder zsFreezeReason = new StringBuilder(1024);
            zsFreezeReason.Append(zsEntity.TopCompany);

            // 1. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2. 跳过值为0的数据
                if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                // 3. 获取对应负数渠道的本期金额的绝对值
                decimal fsCash = Math.Abs(fsEntityItem.LegalFreezeResult.ReCanFreezeCash);

                // 4. 重新调整正数金额
                zsCash = zsCash - fsCash;

                // 5. 更新原始数据中当前法人的相应的负数渠道的冻结信息
                var orgEntity4Fs = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity4Fs.FreezeType = 30;  // 总公司，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Fs.TopCompanyFreezeResult.FreezeCash = fsCash;
                orgEntity4Fs.TopCompanyFreezeResult.ReCanFreezeCash = 0;
                orgEntity4Fs.TopCompanyFreezeResult.FreezeReason = $"{fsEntityItem.TopCompany} {zsEntity.ChannelCode} 冻结了 {fsCash}";

                zsFreezeReason.Append($" {fsEntityItem.ChannelCode} 冻结了 {fsCash}，");
            }

            // 6. 如果有冻结负数渠道，更新原始数据中当前法人的相应的正数渠道的冻结信息
            if (zsEntity.LegalFreezeResult.ReCanFreezeCash > zsCash)
            {
                zsFreezeReason.Length--; // 去掉最后一个中文逗号
                var orgEntity4Zs = excelDataList.FirstOrDefault(x => x.ID == zsEntity.ID);
                orgEntity4Zs.FreezeType = 30;  // 总公司，分组金额总额大于0，只有一个正数渠道抵扣负数
                orgEntity4Zs.TopCompanyFreezeResult.FreezeCash = -(zsEntity.LegalFreezeResult.ReCanFreezeCash - zsCash);
                orgEntity4Zs.TopCompanyFreezeResult.ReCanFreezeCash = zsCash;
                orgEntity4Zs.TopCompanyFreezeResult.FreezeReason = zsFreezeReason.ToString();
            }
        }

        /// <summary>
        /// 处理有多个正数渠道的本期金额的的值的总和大于当前分组的负数渠道的本期金额的总和的绝对值的情况
        /// </summary>
        /// <param name="ZsList"></param>
        /// <param name="FsList"></param>
        /// <param name="groupFsAbs"></param>
        /// <param name="excelDataList"></param>
        private void DueCashGreaterThanZeroIfMulChanel4TopCompany(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, decimal groupFsAbs, ref List<TcReportEntity> excelDataList)
        {
            // 1. 获取大于分组的负数金额绝对值的多个正数渠道
            //    正数渠道按金额升序排序保证筛选出来的这些正数渠道的本期金额的和与负数金额绝对值的差值
            decimal zsCash = 0m;
            List<TcReportEntity> zsListSelected = new List<TcReportEntity>();
            foreach (var zsEntityItem in ZsList)
            {
                zsCash = zsCash + zsEntityItem.LegalFreezeResult.ReCanFreezeCash;
                zsListSelected.Add(zsEntityItem);
                if (zsCash > groupFsAbs) break;
            }

            // 2. 循环遍历负数渠道
            foreach (var fsEntityItem in FsList)
            {
                // 2-1. 跳过值为0的数据
                if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                // 2-2. 循环遍历上一步筛选出来的正数渠道
                decimal freezeCash = 0m;
                //decimal fsCashAbs = Math.Abs(fsEntityItem.LegalFreezeResult.ReCanFreezeCash);
                foreach (var zsEntityItem in zsListSelected)
                {
                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCashAbs = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCashAbs < fsCashAbs ? zsCashAbs : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.TopCompanyFreezeResult.FreezeCash = zsEntityItem.TopCompanyFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.TopCompanyFreezeResult.FreezeReason))
                    {
                        zsEntityItem.TopCompanyFreezeResult.FreezeReason = $"{zsEntityItem.TopCompany} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.TopCompanyFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.TopCompanyFreezeResult.FreezeCash = fsEntityItem.TopCompanyFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash = fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.TopCompanyFreezeResult.FreezeReason))
                    {
                        fsEntityItem.TopCompanyFreezeResult.FreezeReason = $"{fsEntityItem.TopCompany} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.TopCompanyFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-7. 如果负数渠道已经冻结完，跳出正数渠道的循环
                    if (fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in zsListSelected)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 31;  // 总公司，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.TopCompanyFreezeResult.FreezeCash = zsEntityItem.TopCompanyFreezeResult.FreezeCash;
                orgEntity.TopCompanyFreezeResult.ReCanFreezeCash = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                orgEntity.TopCompanyFreezeResult.FreezeReason = zsEntityItem.TopCompanyFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 31;  // 总公司，分组金额总额大于0，有多个正数渠道抵扣负数
                orgEntity.TopCompanyFreezeResult.FreezeCash = fsEntityItem.TopCompanyFreezeResult.FreezeCash;
                orgEntity.TopCompanyFreezeResult.ReCanFreezeCash = fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                orgEntity.TopCompanyFreezeResult.FreezeReason = fsEntityItem.TopCompanyFreezeResult.FreezeReason;
            }
        }

        /// <summary>
        /// 处理分组的本期金额总值小于或等于 0 的业务
        /// </summary>
        private void DueCashLessThanOrEqualZero4TopCompany(List<TcReportEntity> ZsList, List<TcReportEntity> FsList, ref List<TcReportEntity> excelDataList)
        {
            // 1. 循环遍历负数渠道
            foreach (var zsEntityItem in ZsList)
            {
                decimal freezeCash = 0m;

                // 2. 循环遍历负数渠道
                foreach (var fsEntityItem in FsList)
                {
                    // 2-1. 跳过值为0的数据
                    if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-3. 跳过剩余可冻结金额=0的正数渠道
                    if (fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash == 0) continue;

                    // 2-4. 对冲金额的正数渠道和负数渠道的金额（绝对值）的较小者
                    decimal zsCash = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                    decimal fsCashAbs = Math.Abs(fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash);
                    freezeCash = zsCash < fsCashAbs ? zsCash : fsCashAbs;

                    // 2-5. 更新正数渠道的冻结信息
                    zsEntityItem.TopCompanyFreezeResult.FreezeCash = zsEntityItem.TopCompanyFreezeResult.FreezeCash - freezeCash;
                    zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash - freezeCash;
                    if (string.IsNullOrWhiteSpace(zsEntityItem.TopCompanyFreezeResult.FreezeReason))
                    {
                        zsEntityItem.TopCompanyFreezeResult.FreezeReason = $"{zsEntityItem.TopCompany} {fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        zsEntityItem.TopCompanyFreezeResult.FreezeReason += $"，{fsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 2-6. 更新负数渠道的冻结信息
                    fsEntityItem.TopCompanyFreezeResult.FreezeCash = fsEntityItem.TopCompanyFreezeResult.FreezeCash + freezeCash;
                    fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash = fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash + freezeCash;
                    if (string.IsNullOrWhiteSpace(fsEntityItem.TopCompanyFreezeResult.FreezeReason))
                    {
                        fsEntityItem.TopCompanyFreezeResult.FreezeReason = $"{fsEntityItem.TopCompany} {zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }
                    else
                    {
                        fsEntityItem.TopCompanyFreezeResult.FreezeReason += $"，{zsEntityItem.ChannelCode} 冻结了 {freezeCash}";
                    }

                    // 如果正数渠道的金额已经为 0，跳出负数渠道的循环
                    if (zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash == 0) break;
                }
            }

            // 3. 更新 Excel 原始文件数据
            foreach (var zsEntityItem in ZsList)
            {
                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == zsEntityItem.ID);
                orgEntity.FreezeType = 32;  // 总公司，分组金额总额小于等于0
                orgEntity.TopCompanyFreezeResult.FreezeCash = zsEntityItem.TopCompanyFreezeResult.FreezeCash;
                orgEntity.TopCompanyFreezeResult.ReCanFreezeCash = zsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                orgEntity.TopCompanyFreezeResult.FreezeReason = zsEntityItem.TopCompanyFreezeResult.FreezeReason;
            }

            foreach (var fsEntityItem in FsList)
            {
                if (fsEntityItem.LegalFreezeResult.ReCanFreezeCash == 0) continue;

                var orgEntity = excelDataList.FirstOrDefault(x => x.ID == fsEntityItem.ID);
                orgEntity.FreezeType = 32;  // 总公司，分组金额总额小于等于0
                orgEntity.TopCompanyFreezeResult.FreezeCash = fsEntityItem.TopCompanyFreezeResult.FreezeCash;
                orgEntity.TopCompanyFreezeResult.ReCanFreezeCash = fsEntityItem.TopCompanyFreezeResult.ReCanFreezeCash;
                orgEntity.TopCompanyFreezeResult.FreezeReason = fsEntityItem.TopCompanyFreezeResult.FreezeReason;
            }
        }
        #endregion

        #region 总冻结结果
        private void HandleFinalFreezeResult(ref List<TcReportEntity> excelDataList)
        {
            foreach (var item in excelDataList)
            {
                item.FinalFreezeResult.ReCanFreezeCash = item.TopCompanyFreezeResult.ReCanFreezeCash;
                item.FinalFreezeResult.FreezeCash = item.ChainFreezeResult.FreezeCash + 
                                                    item.LegalFreezeResult.FreezeCash + 
                                                    item.TopCompanyFreezeResult.FreezeCash;
                item.FinalFreezeResult.FreezeStatus = item.FinalFreezeResult.FreezeCash == 0 ? "" : "冻结";

                StringBuilder freezeReason = new StringBuilder(1024);
                if (!string.IsNullOrWhiteSpace(item.ChainFreezeResult.FreezeReason))
                {
                    freezeReason.Append(item.ChainFreezeResult.FreezeReason);
                }
                if (!string.IsNullOrWhiteSpace(item.LegalFreezeResult.FreezeReason))
                {
                    if (freezeReason.Length > 0) freezeReason.Append("|");
                    freezeReason.Append(item.LegalFreezeResult.FreezeReason);
                }
                if (!string.IsNullOrWhiteSpace(item.TopCompanyFreezeResult.FreezeReason))
                {
                    if (freezeReason.Length > 0) freezeReason.Append("|");
                    freezeReason.Append(item.TopCompanyFreezeResult.FreezeReason);
                }
                item.FinalFreezeResult.FreezeReason = freezeReason.ToString();
            }
        }

        /// <summary>
        /// 计算最终冻结金额
        /// </summary>
        /// <param name="excelDataList"></param>
        /// <returns></returns>
        private decimal CalcFreezeCash(ref List<TcReportEntity> excelDataList)
        {
            var freezeCash = excelDataList.Sum(x => x.FinalFreezeResult.FreezeCash > 0 ? x.FinalFreezeResult.FreezeCash : 0);
            return freezeCash;
        }
        #endregion

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="excelDataList"></param>
        private string ExportData(string orgFilePath, ref List<TcReportEntity> excelDataList)
        {
            var exportDto = new TcReportExportDto(excelDataList);
            string savePath = Directory.GetParent(orgFilePath).FullName;
            string fileName = string.Format("{0}_处理后_{1}.xlsx", Path.GetFileNameWithoutExtension(orgFilePath), DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string filePath = Path.Combine(savePath, fileName);
            string templatePath = @"ExcelTemplate/TcReportTemplate.xlsx";

            string fileUrl = ExcelUtil.ExportExcelByTemplate(exportDto, filePath, templatePath).Result;
            return fileUrl;
        }
        #endregion

        #region BackgroundWorker
        void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            FrmZqReportHandler win = e.Argument as FrmZqReportHandler;

            string orgFile = txtFile.Text.Trim();
            bw.ReportProgress(1, orgFile);

            // 1. 读取 Excel 表内容
            var excelDataList = ReadExcel(txtFile.Text);
            int c0 = excelDataList.Count;
            bw.ReportProgress(20, c0);

            // 2. 更新excelDataList的连锁冻结信息
            //    冻结金额原始值为0，
            //    剩余可冻结金额为本期金额+冻结金额
            InitChainFreezeData(ref excelDataList);
            bw.ReportProgress(25);

            // 3-1. 获取连锁分组
            var chainGroups = GroupChain(ref excelDataList);
            bw.ReportProgress(30);

            // 3-2. 遍历连锁分组进行处理
            HandleChain(chainGroups, ref excelDataList);
            bw.ReportProgress(40);

            // 4. 初始化excelDataList的法人冻结信息
            InitLegalFreezeData(ref excelDataList);
            bw.ReportProgress(45);

            // 5-1. 获取法人分组
            var legalGroups = GroupLegal(ref excelDataList);
            bw.ReportProgress(50);

            // 5-2. 遍历法人分组进行处理
            HandleLegal(legalGroups, ref excelDataList);
            bw.ReportProgress(60);

            // 6. 初始化excelDataList的总公司冻结信息
            InitTopCompanyFreezeData(ref excelDataList);
            bw.ReportProgress(65);

            // 7-1. 获取总公司分组
            var topcomGroups = GroupTopCompany(ref excelDataList);
            bw.ReportProgress(70);

            // 7-2. 遍历总公司分组进行处理
            HandleTopCompany(topcomGroups, ref excelDataList);
            bw.ReportProgress(80);

            // 8. 处理总冻结结果
            HandleFinalFreezeResult(ref excelDataList);
            decimal freezeCash = CalcFreezeCash(ref excelDataList);
            bw.ReportProgress(85, freezeCash);

            // 9. 导出数据
            var fileUrl = ExportData(orgFile, ref excelDataList);
            bw.ReportProgress(100, fileUrl);
        }

        void UpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            pgBar.Value = progress;

            if (progress == 1)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 选择文件: [{e.UserState}]\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备读取文件内容……\r\n");
            }
            else if (progress == 20)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 读取文件内容完毕，共读取 {e.UserState} 条数据 {Environment.NewLine}");
            }
            else if (progress == 25)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 初始化连锁冻结信息（冻结金额、剩余可冻结金额等）\r\n");
            }
            else if (progress == 30)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 获取连锁分组\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备遍历连锁分组进行处理……\r\n");
            }
            else if (progress == 40)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理完毕连锁分组数据\r\n");
            }
            else if (progress == 45)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 初始化法人冻结信息\r\n");
            }
            else if (progress == 50)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 获取法人分组\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备遍历法人分组进行处理……\r\n");
            }
            else if (progress == 60)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理完毕法人分组数据\r\n");
            }
            else if (progress == 65)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 初始化总公司冻结信息\r\n");
            }
            else if (progress == 70)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 获取总公司分组\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备遍历总公司分组进行处理……\r\n");
            }
            else if (progress == 80)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理完毕总公司分组数据\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备处理最终冻结结果……\r\n");
            }
            else if (progress == 85)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理完毕总冻结结果，共冻结金额 {e.UserState}\r\n");
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 准备导出处理后的文件……\r\n");
            }
            else if (progress == 100)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 导出处理后的数据到 Excel 完毕，处理后的文件是 [{e.UserState}]\r\n");
            }
        }

        void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理过程中出现错误：[{e.Error}]\r\n");
            }
            else
            {
                txtPg.AppendText($"{DateTime.Now.ToyyyyMMddHHmmssfff()} 处理完毕");
            }
        }
        #endregion
    }
}
