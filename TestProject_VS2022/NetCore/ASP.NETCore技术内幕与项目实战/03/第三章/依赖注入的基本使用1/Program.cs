using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();
services.AddTransient<TestServiceImpl>();
using (ServiceProvider sp = services.BuildServiceProvider())
{
    // 服务定位器模式
    // 通过 GetRequiredService 获取 TestServiceImpl 对象
    var ts1 = sp.GetRequiredService<TestServiceImpl>();
    var ts2 = sp.GetRequiredService<TestServiceImpl>();
    Console.WriteLine(Object.ReferenceEquals(ts1, ts2));

    ts1.Name = "tom";
    ts1.SayHi();
}