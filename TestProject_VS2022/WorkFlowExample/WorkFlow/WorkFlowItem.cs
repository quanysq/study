using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowExample.WorkFlow
{
    public class WorkFlowItem
    {
        /// <summary>
        /// 流程顺序
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public StatusType Status { get; set; }

        public string ApprovedUser { get; set; }

        public void Approved(WorkFlow workFlow, Action action)
        {

        }
    }
}
