using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("T_Comments");

        // 一条评论对应一篇文章，一篇文章有多条评论
        builder.HasOne<Article>(c =>c.Article)
            .WithMany(a => a.Comments)
            .IsRequired()
            .HasForeignKey(c => c.ArticleId);
        builder.Property(p=>p.Message).IsRequired().IsUnicode();
    }
}
