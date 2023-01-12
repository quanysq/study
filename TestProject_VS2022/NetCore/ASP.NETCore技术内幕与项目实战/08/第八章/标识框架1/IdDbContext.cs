using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// 使用 Identity 框架要继承 IdentityDbContext
// IdentityDbContext是一个泛型类，有3个泛型参数，分别代表用户类型、角色类型和主键类型
public class IdDbContext: IdentityDbContext<User, Role, long>
{
    public IdDbContext(DbContextOptions<IdDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
