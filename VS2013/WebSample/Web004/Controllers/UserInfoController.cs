using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web004.Common;

namespace Web004.Controllers
{
  public class UserInfoController : ApiController
  {
    [HttpPost]
    public HttpResponseMessage CheckUserName(string userName)
    {
      int num = userName == "admin" ? 1 : 0;
      if (num > 0)
      {
        return CustomControllerResult.MsgFormat(ResponseCode.Fail, "Can't register or user already exist!", "0 " + userName);
      }
      else
      {
        return CustomControllerResult.MsgFormat(ResponseCode.Success, "You can register", "1 " + userName);
      }
    }

    [HttpPost]
    public HttpResponseMessage CheckUserNameWithFromBody([FromBody]object userName)
    {
      int num = Convert.ToString(userName) == "admin" ? 1 : 0;
      if (num > 0)
      {
        return CustomControllerResult.MsgFormat(ResponseCode.Fail, "Can't register or user already exist!", "0 " + userName.ToString());
      }
      else
      {
        return CustomControllerResult.MsgFormat(ResponseCode.Success, "You can register", "1 " + userName.ToString());
      }
    }
  }
}
