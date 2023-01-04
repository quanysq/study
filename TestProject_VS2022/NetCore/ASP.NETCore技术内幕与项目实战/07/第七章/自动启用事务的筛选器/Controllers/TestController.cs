using Microsoft.AspNetCore.Mvc;

namespace 自动启用事务的筛选器.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly MyDbContext dbCtx;

        public TestController(MyDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        [HttpPost]
        public async Task Save()
        {
            dbCtx.Books.Add(new Book { Id = Guid.NewGuid(), Name = "1", Price = 1 });
            await dbCtx.SaveChangesAsync();
            dbCtx.Books.Add(new Book { Id = Guid.NewGuid(), Name = "2", Price = 2 });
            await dbCtx.SaveChangesAsync();
            // 以上代码能够正确地插入两条数据
            // 如果启用以下代码抛出异常，将不会插入数据
            // 说明事务起作用，数据被回滚了
            // throw new Exception();
        }
    }
}