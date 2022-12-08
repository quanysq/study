using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

public class RateLimitFilter : IAsyncActionFilter
{
    private readonly IMemoryCache memCache;

    public RateLimitFilter(IMemoryCache memCache)
    {
        this.memCache = memCache;
    }

    public Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {
        string removeIP = context.HttpContext.Connection.RemoteIpAddress!.ToString();
        string cacheKey = $"LastVisitTick_{removeIP}";
        long? lastTick = memCache.Get<long?>(cacheKey);
        if (lastTick == null || Environment.TickCount64 - lastTick > 1000)
        {
            memCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
            return next();
        }
        else
        {
            //如果IP频繁访问，则不执行 next，相当于终止操作方法的执行
            context.Result = new ContentResult { StatusCode = 429 };
            return Task.CompletedTask;
        }
    }
}
