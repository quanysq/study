using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console007
{
  /// <summary>
  /// 查进程内存
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //getWorkingSet(111);
      Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssffffff"));
    }

    public static int GetProcessMemory(int Pid)
    {
      Process pros = Process.GetProcessById(Pid);
      var p1 = new PerformanceCounter("Process", "Working Set - Private", pros.ProcessName, true);
      return Convert.ToInt32(p1.NextValue() / 1024);

      //Process[] pros = Process.GetProcesses();
      //foreach (Process process in pros)
      //{
      //  if (Pid == process.Id)
      //  {
      //    return Convert.ToInt32(process.PeakWorkingSet64 / 1024 / 1024);
      //  }
      //}
      //return 0;
    }

    public static void getWorkingSet(string processName)
    {
      //var processName = "taskmgr";
      var processlist = Process.GetProcessesByName(processName);
      if (processlist == null || processlist.Length == 0) return;
      var process = processlist[0];
      
      using (var p1 = new PerformanceCounter("Process", "Working Set - Private", processName))
      using (var p2 = new PerformanceCounter("Process", "Working Set", processName))
      {
        Console.WriteLine(process.Id);
        //注意除以CPU数量
        Console.WriteLine("{0}{1:N} KB", "工作集（进程类）", process.WorkingSet64 / 1024);
        Console.WriteLine("{0}{1:N} KB", "工作集 ", p2.NextValue() / 1024);
        Console.WriteLine("{0}{1:N} KB", "私有工作集 ", p1.NextValue() / 1024);
        Console.WriteLine("{0}；内存（专用工作集）{1:N}；PID:{2}；程序名：{3}", DateTime.Now, p1.NextValue() / 1024, process.Id.ToString(), processName);

        // Thread.Sleep(1000);
      }
    }

    public static void getWorkingSet(int Pid)
    {
      using (var process = Process.GetProcessById(Pid))
      using (var p1 = new PerformanceCounter("Process", "Working Set - Private", process.ProcessName))
      using (var p2 = new PerformanceCounter("Process", "Working Set", process.ProcessName))
      {
        //注意除以CPU数量
        Console.WriteLine("{0}{1:N} KB", "工作集（进程类）", process.WorkingSet64 / 1024);
        Console.WriteLine("{0}{1:N} KB", "工作集 ", p2.NextValue() / 1024);
        Console.WriteLine("{0}{1:N} KB", "私有工作集 ", p1.NextValue() / 1024);
        Console.WriteLine("{0}；内存（专用工作集）{1:N}；PID:{2}；程序名：{3}", DateTime.Now, p1.NextValue() / 1024, process.Id.ToString(), process.ProcessName);

        // Thread.Sleep(1000);
      }
    }

    /*
    using (var process = Process.GetProcessById(Pid))
    using (var p1 = new PerformanceCounter("Process", "Working Set - Private", process.ProcessName))
    using (var p2 = new PerformanceCounter("Process", "Working Set", process.ProcessName))
    {
      …… 
    }
    其本质依然是嵌套try{}finally{}，所以还是有一定的风险
    */
  }
}
