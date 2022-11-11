using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class BookEntityConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("T_Books");
        builder.Property(e => e.Title).HasMaxLength(50).IsRequired();
        builder.Property(e => e.AuthorName).HasMaxLength(20).IsRequired();

        // 视图与实体类映射
        //builder.ToView("blogsVeiw");

        // 排除属性映射
        //builder.Ignore(b => b.Title);

        // 对应的数据库表中的列名改为colTitle
        //builder.Property(p => p.Title).HasColumnName("colTitle");

        // EF Core在SQL Server数据库中对于string类型的属性，
        // 默认生成nvarchar类型的列，
        // 可以通过下面的代码把列的数据类型改为varchar
        //builder.Property(p => p.Title).HasColumnType("varchar(200)");

        // EF Core默认把名字为Id或者“实体类型+Id”的属性作为主键，我们可以用HasKey配置其他属性作为主键。比如下面的代码把Number列作为主键：
        //builder.HasKey(e => e.Title);

        // 用HasIndex方法配置索引
        // 可以用IsUnique方法把索引配置为唯一索引
        // 还可以用IsClustered方法把索引设置为聚集索引
        //builder.HasIndex(e => e.Title);
        //builder.HasIndex(e => new { e.Title, e.AuthorName });
    }
}
