using AutoMapperSample;
using Microsoft.Extensions.DependencyInjection;

// 创建依赖注入容器 ServiceCollection
ServiceCollection services = new ServiceCollection();

// 注入 AutoMapper 服务
services.AddAutoMapper(typeof(AutoMappingProfile));

// 注入 PersonService
services.AddTransient<PersonService>();

// 执行 PersonService 中的方法
using (ServiceProvider sp = services.BuildServiceProvider())
{
    // 服务定位器模式，通过 GetRequiredService 获取 PersonService 对象
    var ps = sp.GetRequiredService<PersonService>();
    ps.DoMapping();
}



