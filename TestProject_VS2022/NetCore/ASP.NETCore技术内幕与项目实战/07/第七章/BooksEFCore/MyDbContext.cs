using Microsoft.EntityFrameworkCore;

public class MyDbContext:DbContext
{
    public DbSet<Book> Books { get; set; }

    //在运行时通过读取配置来确定要连接的数据库
    //不再重写OnConfiguring方法和在其中调用UseSqlServer等方法来设置要使用的数据库
    //为MyDbContext类增加了DbContextOptions<MyDbContext>类型参数的构造方法
    //DbContextOptions是一个数据库连接配置对象，在ASP.NET Core项目中提供对DbContextOptions的配置
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
