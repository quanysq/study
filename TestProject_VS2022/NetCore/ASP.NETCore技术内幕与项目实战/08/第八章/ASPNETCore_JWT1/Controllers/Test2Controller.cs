using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCore_JWT1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class Test2Controller : Controller
    {
        [HttpGet]
        public IActionResult Hello()
        {
            string id = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            string userName = this.User.FindFirst(ClaimTypes.Name)!.Value;
            IEnumerable<Claim> roleClaims = this.User.FindAll(ClaimTypes.Role);
            string roleNames = string.Join(",", roleClaims.Select(c => c.Value));
            return Ok($"id={id},userName={userName},roleNames ={roleNames}");
        }
    }
}
