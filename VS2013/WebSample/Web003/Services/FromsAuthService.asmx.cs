using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web003.Services
{
  /// <summary>
  /// Summary description for InteAuth
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class FromsAuthService : System.Web.Services.WebService
  {

    [WebMethod]
    public string HelloWorld()
    {
      return string.Format("Hello Forms authentication, By [{0}, {1}, {2}, {3}]", 
        HttpContext.Current.Request.UserHostAddress, 
        HttpContext.Current.Request.UserHostName, 
        HttpContext.Current.Request.ServerVariables["REMOTE_HOST"],
        HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
    }
  }
}
