using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowExample.WorkFlow
{
    public class WorkFlow
    {
        public List<WorkFlowItem> WorkFlowItems { get; set; }

        public WorkFlowItem CurrentFlowItem { get; private set; }

        private WorkFlowItem GetNextFlowItem()
        {
            return null;
        }
    }
}
