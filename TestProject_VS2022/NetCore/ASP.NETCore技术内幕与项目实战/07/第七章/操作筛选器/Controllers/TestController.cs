using Microsoft.AspNetCore.Mvc;

namespace 操作筛选器.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string GetData()
        {
            Console.WriteLine("执行GetData");
            return "yzk";

            /* 
             *  执行顺序：
             *  MyActionFilter 1:开始执行
             *  MyActionFilter 2:开始执行
             *  执行GetData
             *  MyActionFilter 2:执行成功
             *  MyActionFilter 1:执行成功
            */
        }
    }
}