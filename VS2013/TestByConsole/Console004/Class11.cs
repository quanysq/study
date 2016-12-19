using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// ThreadPool.QueueUserWorkItem - 限定多线程的线程数量 2
  /// </summary>
  public class C11
  {
    public static void Execute()
    {
      DoTest_MultiThread(51);
    }

    static void DoTest_MultiThread(int num)
    {
      int n_max_thread = 10; // 设置并行最大为10个线程
      int n_total_thread = 0; // 用来控制：主程序的结束执行，当所有任务线程执行完毕

      List<int> list_Thread = new List<int>();

      System.Threading.AutoResetEvent wait_sync = new System.Threading.AutoResetEvent(false); // 用来控制：并发最大个数线程=n_max_thread
      System.Threading.AutoResetEvent wait_main = new System.Threading.AutoResetEvent(false); // 用来控制：主程序的结束执行，当所有任务线程执行完毕

      DateTime date_step = DateTime.Now;
      for (long i = 0; i < num; i++)
      {
        if (i > 0 && (i+1) % n_max_thread == 0) // -1 表示第max个线程尚未开始
        {
          Console.WriteLine("WaitOne");
          wait_sync.WaitOne(); // 每次并发10个线程，等待处理完毕后，在发送下一次并发线程
        }


        System.Threading.ThreadPool.QueueUserWorkItem((data) =>
        {
          int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
          System.Threading.Monitor.Enter(list_Thread);
          list_Thread.Add(id);
          System.Threading.Monitor.Exit(list_Thread);

          //TODO
          //System.Threading.Thread.Sleep(1000 * 5);
          Console.WriteLine("[{0}] [i={1}] CurrentThread={2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), i, id);
          //Console.WriteLine("[{0}] CurrentThread={1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);

          n_total_thread += 1;
          if (list_Thread.Count == (n_max_thread) || n_total_thread == num)
          {
            list_Thread.Clear();
            if (n_total_thread != num)
            {
              wait_sync.Set(); // 任务线程，继续执行
            }
            else
            {
              wait_main.Set(); // 主程序线程，继续执行
            }
          }
        }, list_Thread);
      }

      wait_main.WaitOne();

      Console.WriteLine(string.Format("总测试{0}次，总耗时{1}, 平均耗时{2}"
        , num
        , (DateTime.Now - date_step).ToString()
        , (DateTime.Now - date_step).TotalMilliseconds / num));

      //Query_Thread();
    }
  }
}
