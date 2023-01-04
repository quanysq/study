using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;
using 例子服务实现1;
using 例子服务接口1;

class ModuleInitializer : IModuleInitializer
{
    public void Initialize(IServiceCollection services)
    {
        // 把CnService注册为IMyService的实现服务
        services.AddScoped<IMyService, CnService>();
    }
}
