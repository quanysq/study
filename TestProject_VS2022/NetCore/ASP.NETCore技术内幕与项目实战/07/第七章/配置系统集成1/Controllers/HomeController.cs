using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace 配置系统集成1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IOptionsSnapshot<SmtpOptions> smtpOptions;
        private readonly IConnectionMultiplexer connMultiplexer;

        // 通过构造方法注入获取SmtpOptions和Redis连接对象
        public HomeController(
            IOptionsSnapshot<SmtpOptions> smtpOptions,
            IConnectionMultiplexer connMultiplexer)
        {
            this.smtpOptions = smtpOptions;
            this.connMultiplexer = connMultiplexer;
        }

        // 读取配置信息，连接 Redis 读取数据
        [HttpGet]
        public async Task<string> Index()
        {
            var opt = smtpOptions.Value;
            var timeSpan = connMultiplexer.GetDatabase().Ping();
            
            //写入和读取 Key-value
            var database = connMultiplexer.GetDatabase(1);
            await database.StringSetAsync("name", "Jacky");
            string str = await database.StringGetAsync("name");

            return $"Smtp:{opt} timeSpan:{timeSpan} str:{str}";
        }
    }
}