using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace Console005.IIS
{
  /// <summary>
  /// 修改 Default Web Site 站点的 UploadReadAheadSize 值
  /// </summary>
  public class C4
  {
    public static void Execute(string[] args)
    {
      using (ServerManager serverManager = new ServerManager())
      {
        var mySiteName = "Default Web Site";
        Configuration config = serverManager.GetApplicationHostConfiguration();
        ConfigurationSection serverRuntimeSection = config.GetSection("system.webServer/serverRuntime", mySiteName);
        string oldUploadReadAheadSize = serverRuntimeSection["UploadReadAheadSize"].ToString();
        Console.WriteLine("Old UploadReadAheadSize value is [{0}]", oldUploadReadAheadSize);
        serverRuntimeSection["UploadReadAheadSize"] = 1048576;
        string newUploadReadAheadSize = serverRuntimeSection["UploadReadAheadSize"].ToString();
        Console.WriteLine("OldnewUploadReadAheadSize UploadReadAheadSize value is [{0}]", newUploadReadAheadSize);
        serverManager.CommitChanges();
      }
    }
  }
}
