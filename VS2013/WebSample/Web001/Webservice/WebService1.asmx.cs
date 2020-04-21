using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web001.Webservice
{
  /// <summary>
  /// Summary description for WebService1
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  [System.Web.Script.Services.ScriptService]
  public class WebService1 : System.Web.Services.WebService
  {

    [WebMethod]
    public string HelloWorld()
    {
      var s = "abc";
      //System.Threading.Thread.Sleep(1000 * 40);
      return "The reason for this bug may be because the number of log is too much, it is relatively slow that read and write data to the page";
    }
  }
}
