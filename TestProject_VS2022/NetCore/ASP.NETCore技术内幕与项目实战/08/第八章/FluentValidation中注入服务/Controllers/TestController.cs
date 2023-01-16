using Microsoft.AspNetCore.Mvc;

namespace FluentValidation中注入服务.Controllers
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