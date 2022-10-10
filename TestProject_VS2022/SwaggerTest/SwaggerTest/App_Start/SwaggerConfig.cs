using System.Web.Http;
using WebActivatorEx;
using SwaggerTest;
using Swashbuckle.Application;
using System.Reflection;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace SwaggerTest
{
    // ������ Swagger config ����

    /// <summary>
    /// ���� Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// ע��
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        //�������ú�����Swagger��������Ϣ��
                        c.SingleApiVersion("v2", "���� API �ӿ��ĵ�");
                        c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerTest.xml");
                        //��ȡ��Ŀָ��·����xml�ļ�
                        c.CustomProvider((defaultProvider) => new SwaggerCacheProvider(defaultProvider, $@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\SwaggerTest.xml"));
                    })
                .EnableSwaggerUi(c =>
                    {
                        //��������UI�����ϵĶ�����
                        //���غ�����js�ļ���ע�� swagger.js�ļ����Ա�������Ϊ��Ƕ�����Դ���� APIUI.Scripts.swagger.js�����ǣ���Ŀ����->�ļ���->js�ļ��� 
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "SwaggerTest.Scripts.swagger.js");
                    });
        }
    }
}
