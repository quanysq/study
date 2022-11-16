using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class HouseConfig : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("T_Houses");
        builder.Property(p => p.Name).IsUnicode().IsRequired();
        builder.Property(p => p.Owner).IsConcurrencyToken();
    }
}