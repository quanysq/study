using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace 前后端分离的WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LoginResult> Login(LoginRequest loginReq)
        {
            if (loginReq.UserName == "admin" && loginReq.Password == "123456")
            {
                var processes = Process.GetProcesses().Select(x => new ProcessInfo(
                        x.Id, x.ProcessName, x.WorkingSet64
                    )).ToArray();
                return new LoginResult(true, processes);
            }
            else
            {
                return new LoginResult(false, null);
            }
        }
    }
}