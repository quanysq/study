using Microsoft.EntityFrameworkCore;

class TestDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    // OnConfiguring方法用于对程序要连接的数据库进行配置
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(connStr);
        //optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 表示加载当前程序集中所有实现了IEntityTypeConfiguration接口的类
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
