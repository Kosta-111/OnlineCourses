using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class StudentEntityConfigs : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Phone).IsRequired(false);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Balance).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.BirthDate).IsRequired(false);

        builder.HasMany(x => x.Courses).WithMany(x => x.Students);
    }
}
