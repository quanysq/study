/// <summary>
/// 托管服务是以单例的生命周期注册到依赖注入容器中的。
/// 按照依赖注入容器的要求，
/// 长生命周期的服务不能依赖短生命周期的服务，
/// 因此我们可以在托管服务中通过构造方法注入其他生命周期为单例的服务，
/// 但是不能注入生命周期为范围或者瞬态的服务
/// </summary>
public class DemoBgService : BackgroundService
{
    private ILogger<DemoBgService> logger;

    public DemoBgService(ILogger<DemoBgService> logger)
    {
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(5000);
        string s = await File.ReadAllTextAsync("d:/efsql.log");
        await Task.Delay(20000);
        logger.LogInformation(s);
    }
}
