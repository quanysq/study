using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web001
{
  public partial class AntiXssTest : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      btnOK.ServerClick += btnOK_ServerClick;
      if (!IsPostBack)
      {
        string val = Request.QueryString["test"];
        /*Response.Write(val);*/ //触发 xss 攻击
        Response.Write(Microsoft.Security.Application.AntiXss.HtmlEncode(val));
        Response.Write("<br />");
        Response.Write(Microsoft.Security.Application.Encoder.HtmlEncode(val));
        Response.Write("<br />");
        Response.Write(Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(val));
        Response.Write("<br />");
        Response.Write(System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(val, false));
        Response.Write("<br />");
        Response.Write("ok");
      }
    }

    void btnOK_ServerClick(object sender, EventArgs e)
    {
      // Response.Write(txtParam.Value);
      string val = txtParam.Value;
      Response.Write(Microsoft.Security.Application.AntiXss.HtmlEncode(val));
      Response.Write("<br />");
      Response.Write(Microsoft.Security.Application.Encoder.HtmlEncode(val));
      Response.Write("<br />");
      Response.Write(Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(val));
      Response.Write("<br />");
      Response.Write(System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(val, false));
      Response.Write("<br />");
      Response.Write("ok");

      /*
       * .net 4.5 或以上版本使用 System.Web.Security.AntiXss 即可，无需引用 AntiXssLibrary
       */
    }

    // 要用这个才能有效阻止 xss 攻击
    /*protected void Page_Error(object sender, EventArgs e)
    {
      Exception ex = Server.GetLastError();
      if (HttpContext.Current.Server.GetLastError() is HttpRequestValidationException)
      {
        HttpContext.Current.Response.Write("请输入合法的字符串【<a href=\"javascript:history.back(0);\">返回</a>】");
        HttpContext.Current.Server.ClearError();
      }
    }*/
  }
}
