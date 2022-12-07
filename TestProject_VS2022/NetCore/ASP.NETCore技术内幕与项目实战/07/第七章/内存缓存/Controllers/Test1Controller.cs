using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Zack.ASPNETCore;

[ApiController]
[Route("[controller]/[action]")]
public class Test1Controller : ControllerBase
{
    private readonly ILogger<Test1Controller> logger;
    private readonly MyDbContext dbCtx;
    private readonly IMemoryCache memCache;
    private readonly IMemoryCacheHelper memCachehelper;

    public Test1Controller(
        ILogger<Test1Controller> logger,
        MyDbContext dbCtx,
        IMemoryCache memCache,
        IMemoryCacheHelper memCachehelper)
    {
        this.logger = logger;
        this.dbCtx = dbCtx;
        this.memCache = memCache;
        this.memCachehelper = memCachehelper;
    }

    /// <summary>
    /// 使用 IMemoryCache 缓存内存
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Book[]> GetBooks()
    {
        logger.LogInformation("开始执行GetBooks");
        var items = await memCache.GetOrCreateAsync("AllBooks", async (e) => {
            logger.LogInformation("从数据库中读取数据");
            return await dbCtx.Books.ToArrayAsync();
        });
        logger.LogInformation("把数据返回给调用者");
        return items;
    }

    /// <summary>
    /// 绝对过期时间例子
    /// 使用 AbsoluteExpirationRelativeToNow 配置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Book[]> GetBooksWithAbsExpirationTime()
    {
        logger.LogInformation("开始执行 GetBooksWithAbsExpirationTime：" + DateTime.Now);
        var items = await memCache.GetOrCreateAsync("AllBooks1", async (e) => {
            e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
            logger.LogInformation("从数据库中读取数据");
            return await dbCtx.Books.ToArrayAsync();
        });
        logger.LogInformation("GetBooksWithAbsExpirationTime 执行结束");
        return items;
    }

    /// <summary>
    /// 滑动过期时间例子
    /// 使用 SlidingExpiration 配置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Book[]> GetBooksWithSlideExpirationTime()
    {
        logger.LogInformation("开始执行 GetBooksWithSlideExpirationTime：" + DateTime.Now);
        var items = await memCache.GetOrCreateAsync("AllBooks2", async (e) => {
            e.SlidingExpiration = TimeSpan.FromSeconds(10);
            logger.LogInformation("GetBooksWithSlideExpirationTime 从数据库中读取数据");
            return await dbCtx.Books.ToArrayAsync();
        });
        logger.LogInformation("GetBooksWithSlideExpirationTime 执行结束");
        return items;
    }

    /// <summary>
    /// 混合过期时间例子
    /// 同时使用 AbsoluteExpirationRelativeToNow 和 SlidingExpiration 配置
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Book[]> GetBooksWithBlendExpirationTime()
    {
        logger.LogInformation("开始执行 GetBooksWithBlendExpirationTime：" + DateTime.Now);
        var items = await memCache.GetOrCreateAsync("AllBooks3", async (e) => {
            e.SlidingExpiration = TimeSpan.FromSeconds(10);
            e.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            logger.LogInformation("GetBooksWithBlendExpirationTime 从数据库中读取数据");
            return await dbCtx.Books.ToArrayAsync();
        });
        logger.LogInformation("GetBooksWithBlendExpirationTime 执行结束");
        return items;
    }

    /// <summary>
    /// 获取单个 Book
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Book?>> GetBookFromMemberCache(Guid id)
    {
        logger.LogInformation("开始执行 GetBookFromMemberCache");
        string cacheKey = $"Book{id}";
        var book = await memCache.GetOrCreateAsync(cacheKey, async (e) => {
            var b = await dbCtx.Books.FindAsync(id);
            logger.LogInformation("数据库查询：{0}", b == null ? "为空" : "不为空");
            return b;
        });
        logger.LogInformation("GetBookFromMemberCache 执行结束:{0}", book == null ? "为空" : "不为空");
        return book;
    }

    /// <summary>
    /// 使用 IMemoryCacheHelper 缓存内存
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<Book[]> GetBooksWithMemCacheHelper()
    {
        logger.LogInformation("开始执行 GetBooksWithMemCacheHelper");
        var items = await memCachehelper.GetOrCreateAsync("AllBooks4", async (e) => {
            logger.LogInformation("从数据库中读取数据");
            return await dbCtx.Books.ToArrayAsync();
        });
        logger.LogInformation("把数据返回给调用者");
        return items;
    }
}