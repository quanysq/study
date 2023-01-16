using Microsoft.AspNetCore.Mvc;

namespace 内置数据校验.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        // 执行时，自动对 LoginRequest 进行数据校验
        [HttpPost]
        public ActionResult Login(LoginRequest req)
        {
            return Ok(req);
        }
    }
}