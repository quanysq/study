using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console023
{
  /// <summary>
  /// TaskFactory - 限定多线程的线程数量 3 并处理多线程异常
  /// </summary>
  public class C8
  {
    public static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;

    public static void Execute()
    {
      AggregateExceptionCatched += Program_AggregateExceptionCatched;

      try
      {
        Console.WriteLine("Start...");
        DoTest_MultiThread(12);
        Console.WriteLine("End.");
      }
      catch (Exception ex)
      {
        var item = ex.InnerException;
        Console.WriteLine("异常类型： {0}{1} 来自: {2}{3} 异常内容: {4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
      }
    }

    static void DoTest_MultiThread(int num)
    {
      int n_max_thread = 10; // 设置并行最大为10个线程
      var rnd = new Random();
      int count = 0;

      //Task[] TaskList = new Task[n_max_thread];
      List<Task> TaskList = new List<Task>();
      for (int i = 0; i < num; i++)
      {
        var s = rnd.Next(10);
        TaskList.Add(TaskMethod(s, 0));

        count++;
        if (count == n_max_thread)
        {
          Console.WriteLine("Waiting...");
          Task.WaitAll(TaskList.ToArray(), CancellationToken.None);
          count = 0;
          TaskList.Clear();
        }
      }

      if (TaskList.Count > 0)
      {
        Console.WriteLine("Waiting End...");
        Task.WaitAll(TaskList.ToArray(), CancellationToken.None);
        TaskList.Clear();
      }
    }

    static Task TaskMethod(int s, int retry)
    {
      Task task = Task.Run(() =>
                  {
                    try
                    {
                      int id = Task.CurrentId.Value;
                      if (id == 1 || retry > 0)
                      {
                        Console.WriteLine("retry={0}", retry);
                        throw new InvalidOperationException("任务并行编码中产生的未知异常");
                      }
                      Console.WriteLine(string.Format("[{2}] 第{0}个任务（用时{1}秒）已经开始. Retry[{3}]", id, s, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), retry));
                      Thread.Sleep(s * 1000);
                      Console.WriteLine(string.Format("[{2}] 第{0}个任务（用时{1}秒）已经结束", id, s, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    }
                    catch (Exception err)
                    {
                      AggregateExceptionArgs errArgs = new AggregateExceptionArgs() { AggregateException = new AggregateException(err), retry = retry };
                      AggregateExceptionCatched(null, errArgs);
                    }
                  });
      return task;
    }

    static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
    {
      int retry = e.retry + 1;
      if (retry > 5)
      {
        throw e.AggregateException;
      }
      else
      {
        TaskMethod(15, retry).Wait();
      }
    }

    /// <summary>
    /// 失败的方法
    /// </summary>
    /// <param name="s"></param>
    static void ForMethod(int s)
    {
      int retry = 0;
      while (retry <= 5)
      {
        try
        {
          int id = Task.CurrentId.Value;
          if (id == 1)
          {
            throw new InvalidOperationException("任务并行编码中产生的未知异常");
          }
          Console.WriteLine(string.Format("[{2}] 第{0}个任务（用时{1}秒）已经开始", id, s, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
          Thread.Sleep(s * 1000);
          Console.WriteLine(string.Format("[{2}] 第{0}个任务（用时{1}秒）已经结束", id, s, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
        catch
        {
          retry++;
          if (retry > 5)
          {
            throw;
          }
          else
          {
            Console.WriteLine("Ran into Error. Retry[{0}]", retry);
          }
        }
      }
    }
  }
}
