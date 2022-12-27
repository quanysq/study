// 1. 引用日志命名空间
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// 2. 创建依赖注入容器
ServiceCollection services =new ServiceCollection();

// 3. 注入输出到控制台的日志服务
services.AddLogging(log => log.AddConsole());

// 4. 使用
using (var sp = services.BuildServiceProvider())
{
    // 使用 GetRequiredService 获取日志服务
    // 输出日志的时候会把泛型类型 Program 输出，便于定位日志来自哪个类
    // 注意，在注入ILogger服务的时候，不能使用非泛型的ILogger接口，否则是获取不到服务的。
    var logger = sp.GetRequiredService<ILogger<Program>>();
    logger.LogWarning("这是一条警告消息");
    logger.LogError("这是一条错误消息");
    string age = "abc";
    logger.LogInformation("用户输入的年龄：{0}", age);
    //模拟操作失败，输出错误日志
    try
    {
        int i = int.Parse(age);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "解析字符串为int失败");
    }
}