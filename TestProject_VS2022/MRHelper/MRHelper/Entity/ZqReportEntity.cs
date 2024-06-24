using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.ExporterAndImporter.Core;

namespace MRHelper.Entity
{
    /// <summary>
    /// 渠道账期原始报表实体
    /// </summary>
    public class ZqReportEntity
    {
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
        /// 本期金额
        /// </summary>
        [ImporterHeader(Name = "本期金额")]
        public decimal Cash { get; set; }

        /// <summary>
        /// 冻结原因
        /// </summary>
        [ImporterHeader(Name = "冻结原因")]
        public string FreezeReason { get; set; }

        /// <summary>
        /// 是否结算
        /// </summary>
        [ImporterHeader(Name = "是否结算")]
        public string IsSettlement { get; set; }

        /// <summary>
        /// 申请冻结人
        /// </summary>
        [ImporterHeader(Name = "申请冻结人")]
        public string FreezeApplyer { get; set; }

        /// <summary>
        /// 开始冻结时间
        /// </summary>
        [ImporterHeader(Name = "开始冻结时间")]
        public string FreezeBegin { get; set; }

        /// <summary>
        /// 结束冻结时间
        /// </summary>
        [ImporterHeader(Name = "结束冻结时间")]
        public string FreezeEnd { get; set; }

        /// <summary>
        /// 冻结状态
        /// </summary>
        [IEIgnore]
        public string FreezeStatus { get; set; }

        /// <summary>
        /// 冻结类型
        /// </summary>
        [IEIgnore]
        public int FreezeType { get; set; }
    }
}
