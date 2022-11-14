using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class BookEntityConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("T_Books");
        builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Property(p => p.AuthorName).IsRequired().HasMaxLength(20);
    }
}
