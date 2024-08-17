using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.Entity
{
    /// <summary>
    /// 总分公司报表分组实体
    /// </summary>
    public class TcReportGroupEntity
    {
        /// <summary>
        /// 分组关键字段：连锁 / 法人代表 / 总公司
        /// </summary>
        public string GroupKey { get; set; }

        /// <summary>
        /// 分组下所有渠道的总金额
        /// </summary>
        public decimal CashAll { get; set; }

        /// <summary>
        /// 分组下渠道金额是负数的汇总金额
        /// </summary>
        public decimal CashFs { get; set; }

        /// <summary>
        /// 分组下渠道金额是负数的汇总金额(绝对数)
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
