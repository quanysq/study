using Microsoft.AspNetCore.Mvc;

namespace FluentValidation的基本使用.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(LoginRequest req)
        {
            return Ok();
        }
    }
}