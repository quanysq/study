using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowExample.WorkFlow;

namespace WorkFlowExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkFlowOfApproval workFlow = null;
            List<WorkFlowItemOfApproval> workFlowItems = null;
            using (var sr = new StreamReader(@".\json\InitWorkFlowOfApproval.json"))
            {
                var json = sr.ReadToEnd();
                workFlow = JsonConvert.DeserializeObject<WorkFlowOfApproval>(json);
            }

            using (var sr = new StreamReader(@".\json\InitWorkFlowItemList.json"))
            {
                var json = sr.ReadToEnd();
                workFlowItems = JsonConvert.DeserializeObject<List<WorkFlowItemOfApproval>>(json);
            }
            Console.WriteLine("获取工作流数据完成");
            Console.WriteLine("开始工作流模拟...");
            while (true)
            {
                Console.WriteLine("当前登录用户：");
                var logonUser = Console.ReadLine();

                var flowItem = workFlowItems.Find(x => x.ApprovalUser == logonUser && x.Status == StatusType.Ready);
                if (flowItem == null)
                {
                    Console.WriteLine("当前用户 [{0}] 没有要处理的工作流项", logonUser);
                    continue;
                }
                else
                {
                    Console.WriteLine("当前用户 [{0}] 的工作流状态：[{1}]", logonUser, flowItem.Status.ToString());

                    flowItem.Approve((currenFlowItem) =>
                    {
                        // 改变状态
                        currenFlowItem.Reply = "OK";
                        currenFlowItem.Status = StatusType.Complete;
                        Console.WriteLine("SEQ [{0}] 审批完成：[{1}]", currenFlowItem.SEQ, currenFlowItem.Status);
                        // 获取下一个
                        var nextFlowItem = workFlowItems.Find(x => x.SEQ == currenFlowItem.SEQ + 1);
                        if (nextFlowItem == null)
                        {
                            Console.WriteLine("当前已经是最后一个工作流项");
                        }
                        else
                        {
                            Console.WriteLine("下一个工作流项 SEQ 是：[{0}]，审批人是：[{1}]", nextFlowItem.SEQ, nextFlowItem.ApprovalUser);
                            nextFlowItem.Status = StatusType.Ready;
                        }
                    });
                }

                Console.WriteLine("按 Enter 继续，按 Esc 保存数据并退出");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    continue;
                }
                else if (key == ConsoleKey.Escape)
                {
                    Save(workFlow, workFlowItems);
                    break;
                }
            }

            Console.WriteLine("退出工作流模拟");
        }

        /// <summary>
        /// 准备数据
        /// </summary>
        private static void InitData()
        {
            var workFlow = new WorkFlowOfApproval()
            {
                RequestId = 1,
                RequestUser = "Jacky Yang",
                RequestContent = "Out of office",
                RequestStatus = StatusType.Complete
            };

            var workFlowItem = new List<WorkFlowItemOfApproval>()
            {
                new WorkFlowItemOfApproval() { RequestId =1, SEQ=0, Reply="", ApprovalUser="Deng", Status=StatusType.Ready  },
                new WorkFlowItemOfApproval() { RequestId =1, SEQ=1, Reply="", ApprovalUser="He", Status=StatusType.Future  },
                new WorkFlowItemOfApproval() { RequestId =1, SEQ=2, Reply="", ApprovalUser="Huang", Status=StatusType.Future  },
                new WorkFlowItemOfApproval() { RequestId =1, SEQ=3, Reply="", ApprovalUser="Liu", Status=StatusType.Future  }
            };

            string json1 = JsonConvert.SerializeObject(workFlow);
            using (StreamWriter sw = new StreamWriter(@".\json\InitWorkFlowOfApproval.json"))
            {
                sw.Write(json1);
            }

            string json2 = JsonConvert.SerializeObject(workFlowItem);
            using (StreamWriter sw = new StreamWriter(@".\json\InitWorkFlowItemList.json"))
            {
                sw.Write(json2);
            }

            Console.WriteLine("OK");
            //return JsonConvert.DeserializeObject<T>(json);
        }

        private static void Save(WorkFlowOfApproval workFlow, List<WorkFlowItemOfApproval> workFlowItem)
        {
            string json1 = JsonConvert.SerializeObject(workFlow);
            using (StreamWriter sw = new StreamWriter(@".\json\WorkFlowOfApproval.json"))
            {
                sw.Write(json1);
            }

            string json2 = JsonConvert.SerializeObject(workFlowItem);
            using (StreamWriter sw = new StreamWriter(@".\json\WorkFlowItemList.json"))
            {
                sw.Write(json2);
            }
        }
    }
}
