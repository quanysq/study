using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace Web004.Common
{
  public class BasicAuthorizeAttribute : AuthorizeAttribute
  {
    public override void OnAuthorization(HttpActionContext actionContext)
    {
      var authorization = actionContext.Request.Headers.Authorization;
      if ((authorization != null) && (authorization.Parameter != null))
      {
        var encryptTicket = authorization.Parameter;
        if (ValidateTicket(encryptTicket))
        {
          base.IsAuthorized(actionContext);
        }
        else
        {
          HandleUnauthorizedRequest(actionContext);
        }
      }
      else
      {
        var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
        bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
        if (isAnonymous)
        {
          base.OnAuthorization(actionContext);
        }
        else
        {
          HandleUnauthorizedRequest(actionContext);
        }
      }
    }

    protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
    {
      base.HandleUnauthorizedRequest(actionContext);

      var response = actionContext.Response = actionContext.Response ?? new HttpResponseMessage();
      response.StatusCode = HttpStatusCode.Forbidden;
      var content = new
      {
        code = -1,
        success = false,
        errs = new[] { "No authentication!", actionContext.Request.Headers.Authorization.Parameter }
      };
      response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
    }

    private bool ValidateTicket(string encryptTicket)
    {
      /*
      //解密Ticket
      var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

      //从Ticket里面获取用户名和密码
      var index = strTicket.IndexOf("&");
      string strUser = strTicket.Substring(0, index);
      string strPwd = strTicket.Substring(index + 1);

      if (strUser == "admin" && strPwd == "123456")
      {
        return true;
      }
      else
      {
        return false;
      }*/

      encryptTicket = encryptTicket.Trim();
      byte[] decodedBytes = Convert.FromBase64String(encryptTicket);
      string s = new ASCIIEncoding().GetString(decodedBytes);

      string[] userPass = s.Split(new char[] { ':' });
      string username = userPass[0];
      string password = userPass[1];

      if (username == "admin" && password == "123456")
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}