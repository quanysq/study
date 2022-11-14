using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("T_Students");
        builder.Property(p => p.Name).IsUnicode().HasMaxLength(20);
        builder.HasMany<Teacher>(c => c.Teachers).WithMany(t => t.Students)
            .UsingEntity(j => j.ToTable("T_Students_Teachers"));
    }
}

class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("T_Teachers");
        builder.Property(p => p.Name).IsUnicode().HasMaxLength(20);
    }
}