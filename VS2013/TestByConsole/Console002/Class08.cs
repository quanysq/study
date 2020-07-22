using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console002
{
  /// <summary>
  /// 获取 Windows Service 状态，启动/停止 Windows Service
  /// https://docs.microsoft.com/zh-cn/dotnet/api/system.serviceprocess.servicecontroller?redirectedfrom=MSDN&view=netframework-4.8
  /// </summary>
  class C8
  {
    public static void Execute(string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine("please enter the service name.");
        return;
      }
      string service = args[0];
      string operation = args[1];
      SingleServiceOperate(service, operation);

      /*if (args.Length == 1)
      {
        SingleServiceOperate(service);
      }
      else
      {
        var isTask = args[1];
        if (isTask.Equals("t", StringComparison.OrdinalIgnoreCase))
        {
          RunTask(service);
        }
        else if (isTask.Equals("f", StringComparison.OrdinalIgnoreCase))
        {
          SingleServiceOperate(service);
        }
      }*/
    }

    private static void SingleServiceOperate(string service, string operation)
    {
      ServiceController[] services = ServiceController.GetServices();
      Console.WriteLine("Service total: [{0}]", services.Length);
      /*int i = 0;
      foreach (ServiceController sc in services)
      {
        i++;
        if (i > 10) break;
        Console.WriteLine("[{0}] Service: [{1}]", i, sc.ServiceName); // result: ServiceName is NormalizeService
        sc.Dispose();
      }*/
      ServiceController mySC = null;
      try
      {
        mySC = new ServiceController(service);
        var serviceStatus = mySC.Status;
        Console.WriteLine("Service [{0}] initial status = [{1}]", service, serviceStatus);
        Console.WriteLine("Service [{0}] can Pause and Continue = [{1}]", service, mySC.CanPauseAndContinue);
        Console.WriteLine("Service [{0}] can ShutDown = [{1}]", service, mySC.CanShutdown);
        Console.WriteLine("Service [{0}] can Stop = [{1}]", service, mySC.CanStop);
        Console.WriteLine("Service [{0}] DependentServices = [{1}]", service, mySC.DependentServices.Length);

        //if (serviceStatus == ServiceControllerStatus.Running)
        if (operation.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
        {
          Console.WriteLine("Service [{0}] is stopping...", service);
          mySC.Stop();
          while (true)
          {
            mySC.Refresh();
            Console.WriteLine("Service [{0}] status is  [{1}]", service, mySC.Status);
            if (mySC.Status == ServiceControllerStatus.Stopped) break;
            Thread.Sleep(1000);
          }
        }
        //else if (serviceStatus == ServiceControllerStatus.Stopped)
        else if (operation.Equals("start", StringComparison.InvariantCultureIgnoreCase))
        {
          Console.WriteLine("Service [{0}] is starting...", service);
          mySC.Start();
          while (true)
          {
            mySC.Refresh();
            Console.WriteLine("Service [{0}] status is  [{1}]", service, mySC.Status);
            if (mySC.Status == ServiceControllerStatus.Running) break;
            Thread.Sleep(1000);
          }
        }
      }
      catch (InvalidOperationException ex)
      {
        if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
        {
          int errCode = ex.InnerException.GetHashCode(); //ex.InnerException.HResult;
          Console.WriteLine("ERROR: [Msg: {0}] [Code: {1}]", ex.InnerException.Message, errCode);
        }
        //throw;
        Console.WriteLine("InvalidOperationException: [{0}]", ex);
      }
      catch (Exception ex)
      {
        //throw;
        Console.WriteLine("OtherException: [{0}]", ex);
      }
      finally
      {
        mySC.Dispose();
      }
    }

    // test successful
    private static void RunTask(string service)
    {
      List<Task> taskList = new List<Task>();
      Task task1 = GetServiceStatus(service);
      Task task2 = ServiceOperate(service);
      taskList.Add(task1);
      taskList.Add(task2);
      Task.WaitAll(taskList.ToArray(), CancellationToken.None);
      Console.WriteLine("Thread is over.");
    }

    private static Task GetServiceStatus(string service)
    {
      Task task = Task.Run(() => {
        Console.WriteLine("Beginning GetServiceStatus thread...");
        int i = 0;
        while (i < 500)
        {
          i++;
          using (ServiceController sc = new ServiceController(service))
          {
            var serviceStatus = sc.Status;
            Console.WriteLine("[{2}] By GetServiceStatus method: Service [{0}] status is [{1}]", service, serviceStatus, i);
          }
            Thread.Sleep(1000);
        }
      });
      return task;
    }

    private static Task ServiceOperate(string service)
    {
      Task task = Task.Run(() => {
        Console.WriteLine("Beginning ServiceOperate thread...");
        using (ServiceController sc = new ServiceController(service))
        {
          if (sc.Status == ServiceControllerStatus.Running)
          {
            Console.WriteLine("By ServiceOperate method: Service [{0}] is stopping...", service);
            sc.Stop();
          }
          else if (sc.Status == ServiceControllerStatus.Stopped)
          {
            Console.WriteLine("By ServiceOperate method: Service [{0}] is starting...", service);
            sc.Start();
          }
        }
      });
      return task;
    }
  }
}
