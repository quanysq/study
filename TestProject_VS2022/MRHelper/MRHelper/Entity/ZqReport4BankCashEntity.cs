using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.Entity
{
    /// <summary>
    /// 银行账号 / 法人代表金额汇总数据
    /// </summary>
    public class ZqReport4BankCashEntity
    {
        /// <summary>
        /// 银行账号 / 法人代表
        /// </summary>
        public string BankAccountCode { get; set; }

        /// <summary>
        /// 银行账号或法人代表下所有渠道的总金额
        /// </summary>
        public decimal CashAll { get; set; }

        /// <summary>
        /// 银行账号或法人代表下渠道金额是负数的汇总金额
        /// </summary>
        public decimal CashFs { get; set; }

        /// <summary>
        /// 银行账号或法人代表下渠道金额是负数的汇总金额(绝对数)
        /// </summary>
        public decimal CashFsAbs
        {
            get 
            {  
                return Math.Abs(CashFs); 
            }
        }
    }
}
