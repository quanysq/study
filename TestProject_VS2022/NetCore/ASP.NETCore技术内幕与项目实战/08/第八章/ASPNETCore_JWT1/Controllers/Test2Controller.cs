using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCore_JWT1.Controllers
{
    // [Authorize] 特性标识此控制器的方法需要身份授权才能访问
    // 授权中间件会处理其它的
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class Test2Controller : Controller
    {
        [HttpGet]
        public IActionResult Hello()
        {
            // ControllerBase中定义的ClaimsPrincipal类型的User属性代表当前登录用户的身份信息
            // 可以通过ClaimsPrincipal的Claims属性获得当前登录用户的所有Claim信息
            // this.User.Claims

            string id = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            string userName = this.User.FindFirst(ClaimTypes.Name)!.Value;
            IEnumerable<Claim> roleClaims = this.User.FindAll(ClaimTypes.Role);
            string roleNames = string.Join(",", roleClaims.Select(c => c.Value));
            return Ok($"id={id},userName={userName},roleNames ={roleNames}");
        }
    }
}
