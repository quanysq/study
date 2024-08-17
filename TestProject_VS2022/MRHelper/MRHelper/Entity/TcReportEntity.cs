using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.ExporterAndImporter.Core;

namespace MRHelper.Entity
{
    /// <summary>
    /// 总分公司渠道金额原始报表实体
    /// </summary>
    public class TcReportEntity
    {
        /// <summary>
        /// 序号，因为渠道编码可能不是唯一的
        /// </summary>
        [IEIgnore]
        public int ID { get; set; } 

        /// <summary>
        /// 渠道类型
        /// </summary>
        [ImporterHeader(Name = "渠道类型")]
        public string ChannelType { get; set; }

        /// <summary>
        /// 渠道编码
        /// </summary>
        [ImporterHeader(Name = "渠道编码")]
        public string ChannelCode { get; set; }

        /// <summary>
        /// 账户性质
        /// </summary>
        [ImporterHeader(Name = "账户性质")]
        public string AccountNature { get; set; }

        /// <summary>
        /// 分公司
        /// </summary>
        [ImporterHeader(Name = "分公司")]
        public string SubCompany { get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        [ImporterHeader(Name = "渠道名称")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        [ImporterHeader(Name = "账户名称")]
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [ImporterHeader(Name = "银行账号")]
        public string BankAccountCode { get; set; }

        /// <summary>
        /// 渠道所属公司名称
        /// </summary>
        [ImporterHeader(Name = "渠道所属公司名称")]
        public string ChannelBelongCompany { get; set; }

        /// <summary>
        /// 总公司
        /// </summary>
        [ImporterHeader(Name = "总公司")]
        public string TopCompany { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        [ImporterHeader(Name = "法人代表")]
        public string Legaler { get; set; }

        /// <summary>
        /// 法人/负责人身份证号码
        /// </summary>
        [ImporterHeader(Name = "法人/负责人身份证号码")]
        public string LegalerCode { get; set; }

        /// <summary>
        /// 连锁
        /// </summary>
        [ImporterHeader(Name = "连锁")]
        public string Chain { get; set; }

        /// <summary>
        /// 本期金额
        /// </summary>
        [ImporterHeader(Name = "本期金额")]
        public decimal Cash { get; set; }

        /// <summary>
        /// 冻结类型
        /// </summary>
        [IEIgnore]
        public int FreezeType { get; set; }

        /// <summary>
        /// 连锁冻结结果
        /// </summary>
        [IEIgnore]
        public FreezeInfo ChainFreezeResult { get; set; } = new FreezeInfo();

        /// <summary>
        /// 法人冻结结果
        /// </summary>
        [IEIgnore]
        public FreezeInfo LegalFreezeResult { get; set; } = new FreezeInfo();

        /// <summary>
        /// 总公司冻结结果
        /// </summary>
        [IEIgnore]
        public FreezeInfo TopCompanyFreezeResult { get; set; } = new FreezeInfo();

        /// <summary>
        /// 最终冻结结果
        /// </summary>
        [IEIgnore]
        public FreezeResult FinalFreezeResult { get; set; } = new FreezeResult();
    }

    /// <summary>
    /// 冻结信息
    /// </summary>

    public class FreezeInfo 
    {
        /// <summary>
        /// 冻结金额
        /// </summary>
        public decimal FreezeCash { get; set; }

        /// <summary>
        /// 剩余可冻结金额
        /// </summary>
        public decimal ReCanFreezeCash { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FreezeReason { get; set; }
    }

    /// <summary>
    /// 总冻结结果
    /// </summary>
    public class FreezeResult : FreezeInfo
    {
        /// <summary>
        /// 是否冻结
        /// </summary>
        public string FreezeStatus { get; set; }
    }
}
