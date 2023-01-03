using Microsoft.EntityFrameworkCore;
using System.Text;

public class ExplortStatisticBgService : BackgroundService
{
    private readonly TestDbContext ctx;
    private readonly ILogger<ExplortStatisticBgService> logger;
    private readonly IServiceScope serviceScope;

    /// <summary>
    /// 在构造方法注入IServiceScopeFactory服务，
    /// 用来创建IServiceScope对象，
    /// 这样就可以通过IServiceScope来创建短生命周期的服务了
    /// </summary>
    /// <param name="scopeFactory"></param>
    public ExplortStatisticBgService(IServiceScopeFactory scopeFactory)
    {
        this.serviceScope = scopeFactory.CreateScope();
        var sp = serviceScope.ServiceProvider;
        this.ctx = sp.GetRequiredService<TestDbContext>();
        this.logger = sp.GetRequiredService<ILogger<ExplortStatisticBgService>>();  
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // 用 while 循环实现服务常驻
        while (!stoppingToken.IsCancellationRequested)
        {
            // 用 try...catch 捕捉异常记录错误信息并避免方法退出
            try
            {
                // 这里实现每隔5秒从数据库中导出数据
                // 更复杂的配置可以用第三方开源的框架
                await DoExecuteAsync();
                await Task.Delay(5000);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "获取用户统计数据失败");
                await Task.Delay(1000);
            }
        }
    }

    private async Task DoExecuteAsync()
    {
        var items = ctx.Users.AsNoTracking().GroupBy(u => u.CreationTime.Date)
            .Select(e => new 
            { 
                Date = e.Key,
                Count = e.Count()
            });
        StringBuilder sb = new StringBuilder(1024);
        sb.AppendLine($"Date: {DateTime.Now}");
        foreach (var item in items)
        {
            sb.Append(item.Date).AppendLine($": {item.Count}");
        }
        await File.WriteAllTextAsync("d:/1.txt", sb.ToString());
        logger.LogInformation($"导出完成");
    }

    /// <summary>
    /// IServiceScope 需要释放
    /// 所以重写 Dispose 方法
    /// </summary>
    public override void Dispose()
    {
        base.Dispose();
        serviceScope.Dispose();
    }
}
