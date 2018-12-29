using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web003
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string user = Request["UserName"].Trim();
      string password = Request["Password"].Trim();
      if (ValidateUser(user, password) == true)
      {
        FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, user, DateTime.Now, DateTime.Now.AddMinutes(30), true, "管理员,会员", "/");
        string HashTicket = FormsAuthentication.Encrypt(Ticket);
        HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);
        Context.Response.Cookies.Add(UserCookie);
        FormsAuthentication.RedirectFromLoginPage(user, false);
        //Response.Redirect("Index.aspx");
      }
      else
      {
        FormsAuthentication.RedirectToLoginPage();
      }
    }

    private bool ValidateUser(string userName, string pwd)
    {
      if (userName.Equals("admin") && pwd.Equals("123456"))
      {
        return true;
      }
      return false;
    }
  }
}