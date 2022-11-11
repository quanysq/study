using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class LeaveConfig : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.ToTable("T_Leaves");
        builder.HasOne<User>(c => c.Requester).WithMany();
        builder.HasOne<User>(c => c.Approver).WithMany();
        builder.Property(p => p.Remarks).HasMaxLength(1000).IsUnicode();
    }
}
