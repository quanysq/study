using System.Web.Http;
using WebActivatorEx;
using SwaggerTest;
using Swashbuckle.Application;
using System.Reflection;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace SwaggerTest
{
    // 完整版 Swagger config 代码

    /// <summary>
    /// 配置 Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 注册
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        //用于启用和设置Swagger的配置信息。
                        c.SingleApiVersion("v2", "测试 API 接口文档");
                        c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerTest.xml");
                        //获取项目指定路径下xml文件
                        c.CustomProvider((defaultProvider) => new SwaggerCacheProvider(defaultProvider, $@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerTest.xml"));
                    })
                .EnableSwaggerUi(c =>
                    {
                        //用于启用UI界面上的东西。
                        //加载汉化的js文件，注意 swagger.js文件属性必须设置为“嵌入的资源”。 APIUI.Scripts.swagger.js依次是：项目名称->文件夹->js文件名 
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "SwaggerTest.Scripts.swagger.js");
                    });
        }
    }
}
