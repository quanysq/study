using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace Console005.IIS
{
  /// <summary>
  /// 设置本地IIS应用连接池的闲置时间为120分钟
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      SetApplicationPoolIdleTimeut("EFSample");
    }

    static void SetApplicationPoolIdleTimeut(string AppPoolName)
    {
      ServerManager sm = new ServerManager();
      string oldtime = sm.ApplicationPools[AppPoolName].ProcessModel.IdleTimeout.TotalMinutes.ToString();
      Console.WriteLine(oldtime);

      sm.ApplicationPools[AppPoolName].ProcessModel.IdleTimeout = new TimeSpan(2, 0, 0);

      string newtime = sm.ApplicationPools[AppPoolName].ProcessModel.IdleTimeout.TotalMinutes.ToString();
      Console.WriteLine(newtime);

      sm.CommitChanges();

      Console.ReadKey();
    }
  }
}
