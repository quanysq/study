using Microsoft.AspNetCore.Mvc;
using AttributeSample;
using System.Reflection;

namespace AttributeSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            Type t = typeof(Points);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                string propertyName = pi.Name;
                string displayName = pi.GetCustomAttribute<TestAttribute>()?.DisplayName!;
                int displayWidth = pi.GetCustomAttribute<TestAttribute>().DisplayWidth;
                _logger.LogInformation("属性名称：" + propertyName + "；显示名称：" + displayName + "；显示宽度：" + displayWidth);
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [TypeFilter(typeof(TestActionFilterAttribute))]
        [TypeFilter(typeof(Test2ActionFilterAttribute))]
        [Test3ActionFilter("Jacky")]
        public IEnumerable<WeatherForecast> Get()
        {
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            _logger.LogInformation("执行方法...");
            return list;
        }
    }

    public class Points
    {
        [Test("站点名称", 100)]
        public string StationNo { get; set; }

        [Test("P1数据名称", 100)]
        public float TD_P1 { get; set; }

        [Test("P2数据名称", 100)]
        public float TD_P2 { get; set; }
    }
}