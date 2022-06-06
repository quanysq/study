using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowExample.WorkFlow
{
    /// <summary>
    /// 流程状态枚举
    /// </summary>
    public enum StatusType
    {
        //可以进行审批的状态
        Ready,

        //完成：当前节点Complete，下一节点Ready
        Complete,

        //拒绝
        Refuse,

        //未走到的节点状态
        Future,    

        //撤销
        Cancel
    }

    public enum FlowType
    {
        Then,
        Parallel
    }
}
