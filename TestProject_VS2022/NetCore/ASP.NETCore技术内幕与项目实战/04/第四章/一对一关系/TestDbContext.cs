using Microsoft.EntityFrameworkCore;

class TestDbContext: DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 表示加载当前程序集中所有实现了IEntityTypeConfiguration接口的类
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}