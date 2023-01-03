using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// IEntityTypeConfiguration的泛型参数类指定这个类要对实体类 Article 进行配置
class ArticleConfig : IEntityTypeConfiguration<Article>
{
    // 使用Fluent API的方式对实体类进行配置
    // 也可以在实体类中使用 Data Annotation 进行配置，但那样耦合太深，不推荐使用
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        // 表示这个实体类对应数据库中名字为T_Articles的表
        builder.ToTable("T_Articles");
        builder.Property(p => p.Content).IsRequired().IsUnicode();
        builder.Property(p => p.Title).IsRequired().IsUnicode()
            .HasMaxLength(255);
    }
}