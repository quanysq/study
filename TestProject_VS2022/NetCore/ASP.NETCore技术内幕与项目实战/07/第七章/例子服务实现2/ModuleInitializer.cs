using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;
using 例子服务实现2;
using 例子服务接口1;

class ModuleInitializer : IModuleInitializer
{
    public void Initialize(IServiceCollection services)
    {
        // 把EnService注册为IMyService的实现服务
        services.AddScoped<IMyService, EnService>();
    }
}
