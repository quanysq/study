using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

public class RateLimitFilter : IAsyncActionFilter
{
    private readonly IMemoryCache memCache;

    // 注入的IMemoryCache
    public RateLimitFilter(IMemoryCache memCache)
    {
        this.memCache = memCache;
    }

    public Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {
        // 通过注入的IMemoryCache来记录用户上一次访问的时间戳
        // 在分布式系统下可以改用分布式缓存来代替内存缓存
        string removeIP = context.HttpContext.Connection.RemoteIpAddress!.ToString();
        string cacheKey = $"LastVisitTick_{removeIP}";
        // 从缓存中获取这个客户端IP地址上一次访问服务器的时间
        long? lastTick = memCache.Get<long?>(cacheKey);
        if (lastTick == null || Environment.TickCount64 - lastTick > 1000)
        {
            // 如果缓存中不存在上一次访问时间或者上一次访问时间距离现在已经超过1s，则通过next来执行后面的筛选器
            memCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
            return next();
        }
        else
        {
            //否则说明IP频繁访问，不执行 next，相当于终止操作方法的执行
            context.Result = new ContentResult { StatusCode = 429 };
            return Task.CompletedTask;
        }
    }
}
