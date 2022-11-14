using Microsoft.EntityFrameworkCore;

class TestDbContext:DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "Server=(localdb)\\mssqllocaldb;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(connStr);

        optionsBuilder.LogTo(msg => {
            if (msg.Contains("CommandExecuted"))
            {
                Console.WriteLine(msg);
            }
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
