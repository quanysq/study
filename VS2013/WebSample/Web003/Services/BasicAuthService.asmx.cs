using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;

namespace Web003.Services
{
  /// <summary>
  /// Summary description for BasicAuthService
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class BasicAuthService : System.Web.Services.WebService
  {
    [WebMethod]
    public string HelloWorld()
    {
      return "Hello World";
    }

    /*
     * 1. Basic auth 的设置是全局性的，即不能在单独一个 asmx 设置 basic auth
     * 2. 主要起作用的类是：Web003.Util.BasicAuthHttpModule
     * 3. Web.config 要作以下配置：
     *    -----------------
     *    <system.web>
     *      ...
     *      <authentication mode="None" />
     *      ...
     *    </system.web>
     *    <system.webServer>
     *      ...
     *      <modules runAllManagedModulesForAllRequests="true">
     *        <add name="BasicAuthHttpModule" type="Web003.Util.BasicAuthHttpModule, Web003" />
     *      </modules>
     *      ...
     *    </system.webServer>
     */
  }
}
