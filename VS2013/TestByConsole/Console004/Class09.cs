using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console004.Class;

namespace Console004
{
  /// <summary>
  /// 处理多线程中的异常
  /// </summary>
  public class C9
  {
    private static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;

    public static void Execute()
    {
      AggregateExceptionCatched += Program_AggregateExceptionCatched;
      for (int i = 0; i < 3; i++)
      {
        TaskMethod(0);
      }
        
      Console.WriteLine("主线程马上结束");
    }

    static void TaskMethod(int retry)
    {
      Task t = new Task(() =>
      {
        try
        {
          Console.WriteLine(retry);
          throw new InvalidOperationException("任务并行编码中产生的未知异常");
        }
        catch (Exception err)
        {
          AggregateExceptionArgs errArgs = new AggregateExceptionArgs() { AggregateException = new AggregateException(err), retry = retry };
          AggregateExceptionCatched(null, errArgs);
        }
      });
      t.Start();
    }

    static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
    {
      int retry = e.retry + 1;
      if (retry > 5)
      {
        var item = e.AggregateException.InnerException;
        Console.WriteLine("异常类型： {0}{1} 来自: {2}{3} 异常内容: {4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
      }
      else
      {
        TaskMethod(retry);
      }
    }
  }
}
