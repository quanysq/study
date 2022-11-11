using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("T_Articles");
        builder.Property(p => p.Content).IsRequired().IsUnicode();
        builder.Property(p => p.Title).IsRequired().IsUnicode()
            .HasMaxLength(255);
    }
}