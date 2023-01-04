using Microsoft.AspNetCore.Mvc;
using 服务注入1;

namespace 服务注入1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        // 1.定义自定义服务
        private readonly MyService1 _myService1;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        // 2.通过构造方法注入
        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyService1 myService1)
        {
            _logger = logger;
            _myService1 = myService1;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // 3.直接使用服务的方法
        [HttpGet]
        public string Test2(string name)
        {
            var names = _myService1.GetNames();
            return string.Join(",", names) + ",hello:" + name;
        }

        // 4.方法参数注入，用于使用频率比较低的服务
        // [FromServices] MyService1 _myService2
        // 只有ASP.NET Core的控制器类的操作方法才能用[FromServices]注入服务，普通的类是不支持这种写法的
        [HttpGet]
        public string Test([FromServices] MyService1 _myService2, string name)
        {
            // 直接使用服务的方法
            var names = _myService2.GetNames();
            return string.Join(",", names) + ",hello:" + name;
        }
    }
}