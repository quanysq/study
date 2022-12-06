using Microsoft.AspNetCore.Mvc;

namespace 客户端响应缓存.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        [HttpGet]
        //ResponseCache在客户端添加cache-control响应报文头，缓存60秒
        //浏览器端禁用缓存之后，客户端和服务器端缓存都会失效
        [ResponseCache(Duration = 60)]  
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}