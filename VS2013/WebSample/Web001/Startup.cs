using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web001.Startup))]
namespace Web001
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
