using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniProfilerDemo.Startup))]
namespace MiniProfilerDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
