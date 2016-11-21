using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console023
{
  class C3
  {
    public static void Execute()
    {
      CancellationTokenSource cts = new CancellationTokenSource();
      Task<int> t = new Task<int>(() => Add(cts.Token), cts.Token);
      t.Start();
      t.ContinueWith(TaskEnded);
      //等待按任意键取消任务
      Console.ReadKey();
      cts.Cancel();
      Console.ReadKey();
    }

    static void TaskEnded(Task<int> task)
    {
      Console.WriteLine("任务完成，完成时候的状态为：");
      Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
      Console.WriteLine("任务的返回值为： {0}", task.Result);
    }

    static int Add(CancellationToken ct)
    {
      Console.WriteLine("任务开始...");
      int result = 0;
      while (!ct.IsCancellationRequested)
      {
        result++;
        Thread.Sleep(1000);
      }
      return result;
    }
  }
}
