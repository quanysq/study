using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web003.Services
{
  /// <summary>
  /// Summary description for WindowsAuthService
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class WindowsAuthService : System.Web.Services.WebService
  {

    [WebMethod]
    public string HelloWorld()
    {
      return string.Format("Hello Windows authentication, By [{0}, {1}, {2}]", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]);
    }

    /*
     * Windows 认证：
     * 1. web.config 设置 <authentication mode="Windows" /> (注：可设可不设)
     * 2. IIS 安装 Windows 身份验证 (控制面板->程序和功能->打开和关闭Windows功能->Internet信息服务->万维网服务->安全性，选择Windows身份验证)
     * 3. Enabled "IIS - Authentication - Windows Authentication"
     */
  }
}
