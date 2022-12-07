using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Zack.ASPNETCore;

namespace 分布式缓存.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        private readonly IDistributedCache distCache;
        private readonly IDistributedCacheHelper helper;
        public Test1Controller(
            IDistributedCache distCache,
            IDistributedCacheHelper helper)
        {
            this.distCache = distCache;
            this.helper = helper;
        }

        [HttpGet]
        public string Now()
        {
            var cacheKey = "Now";
            string? s = distCache.GetString(cacheKey);
            if (s == null)
            {
                s = DateTime.Now.ToString();
                var opt = new DistributedCacheEntryOptions();
                opt.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                distCache.SetString(cacheKey, s, opt);
            }
            return s;
        }

        [HttpGet]
        public async Task<string> NowWithHelper()
        {
            //var result = await helper.GetOrCreateAsync<string>("Now2", async (e) => { 
            //    return DateTime.Now.ToString();
            //});

            //简化写法
            var result = await helper.GetOrCreateAsync<string>("Now2", async e => DateTime.Now.ToString());

            return result;
        }
    }
}