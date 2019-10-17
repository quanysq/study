using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace Console005.IIS
{
  /// <summary>
  /// Get Application Pool Identity programmatically
  /// </summary>
  public class C3
  {
    public static void Execute(string[] args)
    {
      string connString1 = "data source=zothos.argonath.com;initial catalog=BDNA_PUBLISH;persist security info=True;MultipleActiveResultSets=True;App=EntityFramework;Integrated Security=True";
      var i1 = connString1.IndexOf("Integrated Security=True", StringComparison.OrdinalIgnoreCase);
      Console.WriteLine("Have Integrated Security=True: [{0}]", i1);

      string connString2 = "Data Source=zothos.argonath.com;;Initial Catalog=BDNA_PUBLISH;persist security info=True;user id=sa;password=Simple.0;MultipleActiveResultSets=True;App=EntityFramework;Integrated Security=False";
      var i2 = connString2.IndexOf("Integrated Security=True", StringComparison.OrdinalIgnoreCase);
      Console.WriteLine("Don't have Integrated Security=True: [{0}]", i2);

      var appPoolName = "";
      if (args.Length == 0)
      {
        appPoolName = "bdna-api";
      }
      else
      {
        appPoolName = args[0];
      }

      var serverManager = new ServerManager();
      ApplicationPool appPool = serverManager.ApplicationPools[appPoolName];
      Console.WriteLine("IdentityType: [{0}]", appPool.ProcessModel.IdentityType);
      //appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
      var user = appPool.ProcessModel.UserName;
      var pwd = appPool.ProcessModel.Password;
      Console.WriteLine("User: [{0}], Pwd: [{1}]", user, pwd);
    }
  }
}
