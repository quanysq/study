using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

//在多项目的环境下执行EF Core的数据库迁移有很多特殊的要求
//容易出错，因为数据库连接在其它项目中
//可以通过IDesignTimeDbContextFactory接口来解决这个问题
//当项目中存在一个IDesignTimeDbContextFactory接口的实现类的时候，
//数据库迁移工具就会调用这个实现类的CreateDbContext方法来获取上下文对象，
//然后迁移工具会使用这个上下文对象来连接数据库
//此代码只用于开发环境
//生产环境可以去掉此代码
class MyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<MyDbContext> builder = new();
        string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        //也可以从环境变量或者其它配置文件中读取，如下：
        //string connStr = Environment.GetEnvironmentVariable("ConnectionStrings:BooksEFCore");
        builder.UseSqlServer(connStr);
        return new MyDbContext(builder.Options);
    }
}
