using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowExample.WorkFlow
{
    /// <summary>
    /// 审批工作流程
    /// </summary>
    public class WorkFlowOfApproval
    {
        /// <summary>
        /// 申请ID
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string RequestUser { get; set; }

        /// <summary>
        /// 申请事项
        /// </summary>
        public string RequestContent { get; set; }

        /// <summary>
        /// 申请状态
        /// </summary>
        public StatusType RequestStatus { get; set; }
    }

    public class WorkFlowItemOfApproval
    {
        /// <summary>
        /// 申请ID
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// 审批顺序
        /// </summary>
        public int SEQ { get; set; }

        /// <summary>
        /// 审批回复内容
        /// </summary>
        public string Reply { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// 审批用户
        /// </summary>
        public string ApprovalUser { get; set; }

        /// <summary>
        /// 审批操作
        /// </summary>
        /// <param name="action"></param>
        public void Approve(Action<WorkFlowItemOfApproval> action)
        {
            action(this);
        }
    }
}
