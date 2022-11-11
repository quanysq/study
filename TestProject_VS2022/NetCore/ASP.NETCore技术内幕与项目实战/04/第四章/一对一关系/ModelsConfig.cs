using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("T_Orders");
        builder.Property(p => p.Address).IsUnicode();
        builder.Property(p => p.Name).IsUnicode();
        builder.HasOne<Delivery>(c => c.Delivery).WithOne(d => d.Order)
            .HasForeignKey<Delivery>(d => d.OrderId);
    }
}

class DeliveryConfig : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("T_Deliveries");
        builder.Property(p => p.CompanyName).IsUnicode()
            .HasMaxLength(10);
        builder.Property(p => p.Number).HasMaxLength(50);
    }
}
