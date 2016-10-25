using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web002
{
  public partial class Login : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      string user = this.txtUserName.Text; //读取用户名
      string password = this.txtPassword.Text; //读取密码
      if (ValidateUser(user, password) == true) //ValidateUser方法用来验证用户合法性的
      {
        //建立表单验证票据
        FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, user, DateTime.Now, DateTime.Now.AddMinutes(30), true, "管理员,会员", "/");

        //使用webcongfi中定义的方式,加密序列化票据为字符串
        string HashTicket = FormsAuthentication.Encrypt(Ticket);

        //将加密后的票据转化成cookie
        HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);

        //添加到客户端cookie
        Context.Response.Cookies.Add(UserCookie);

        //登录成功后重定向
        //Response.Redirect("GotoUrl.aspx?returnUrl=" + Server.UrlEncode("Default.aspx"));
        FormsAuthentication.RedirectFromLoginPage(user, false);
      }
      else
      {
        //登录失败后的处理
      }
    }

    /// <summary>
    /// 验证用户名/密码是否正确
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    private bool ValidateUser(string userName, string pwd)
    {
      return true; //当然实际开发中，您可以到数据库里查询校验，这里只是示例而已
    }
  }
}