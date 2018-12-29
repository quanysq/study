using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Web001
{
  public class Global : HttpApplication
  {
    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    // 必须加上 Server.ClearError() 才能有效过滤 xss 攻击
    void Application_Error(Object sender, EventArgs e)
    {
      Exception ex = Server.GetLastError();
      Response.Write("Invalid parameters!");
      Server.ClearError();
    }
  }
}