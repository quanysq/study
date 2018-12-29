using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Web003.Util;

namespace Web003.Services
{
  /// <summary>
  /// Summary description for SoapAuthService
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class SoapAuthService : System.Web.Services.WebService
  {
    public SoapHeaderHelper myHeader = new SoapHeaderHelper();

    [SoapHeader("myHeader")]
    [WebMethod]
    public string HelloWorld()
    {
      if (myHeader.CheckLogin())
      {
        return "Hello World";
      }
      return "No authorization!";
    }
  }
}
