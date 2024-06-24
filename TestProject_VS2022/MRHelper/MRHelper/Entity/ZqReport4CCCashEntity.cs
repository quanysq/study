using Magicodes.ExporterAndImporter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.Entity
{
    /// <summary>
    /// 银行账号渠道组合金额实体类
    /// </summary>
    public class ZqReport4CCCashEntity
    {
        private List<string> channelCodeList = new List<string>();

        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankAccountCode { get; set; }

        /// <summary>
        /// 渠道编码组合列表
        /// </summary>
        public List<string> ChannelCodeList {
            get
            {
                return channelCodeList;
            }
            
            set 
            { 
                channelCodeList = value; 
            }
        }

        /// <summary>
        /// 渠道组合金额
        /// </summary>
        public decimal CCCash { get; set; }
    }
}
