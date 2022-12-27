// 1. 引入依赖注入、配置等命名空间
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// 2. 读取配置文件
ConfigurationBuilder configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);   
IConfigurationRoot config = configBuilder.Build();

// 3. 创建依赖注入容器
ServiceCollection services = new ServiceCollection();

// 4.1 选项方式注入配置服务
services.AddOptions()
    .Configure<DbSettings>(e => config.GetSection("DB").Bind(e))
    .Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));

// 4.2 注入读取配置的服务
services.AddTransient<Demo>();

// 5. 使用
using (var sp = services.BuildServiceProvider())
{
    // 建立了一个无限循环，方便修改配置文件反复测试
    while (true)
    {
        using (var scope = sp.CreateScope())
        {
            var spScope = scope.ServiceProvider;
            var demo = spScope.GetRequiredService<Demo>();
            demo.Test();
        }
        Console.WriteLine("可以改配置啦");
        Console.ReadKey();
    }
}