using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web002
{
  public partial class Logout : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Session.Abandon();
      Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
      FormsAuthentication.SignOut();
      //Response.Redirect("default.aspx");
      FormsAuthentication.RedirectToLoginPage();

      
    }
  }
}