using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// System.Threading.Tasks.Parallel and System.Threading.Tasks.Task
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      ExecuteWithParallel();
      Console.WriteLine(new string('=', 20));
      ExecuteWithTask();
    }

    private static void ExecuteWithParallel()
    {
      Console.WriteLine("ExecuteWithParallel");
      Parallel.Invoke(
        () => Console.WriteLine("Run task A"),
        () => Console.WriteLine("Run task B"),
        () => Console.WriteLine("Run task B")
        );
    }

    private static void ExecuteWithTask()
    {
      Console.WriteLine("ExecuteWithTask");
      Task[] tasks = new Task[] { 
        Task.Factory.StartNew(() => Console.WriteLine("Run task A")),
        Task.Factory.StartNew(() => Console.WriteLine("Run task B")),
        Task.Factory.StartNew(() => Console.WriteLine("Run task C"))
      };
      Task.WaitAll(tasks);
    }
  }
}
