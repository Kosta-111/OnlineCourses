using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class CourseEntityConfigs : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ImageUrl).IsRequired(false).HasMaxLength(1024);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(x => x.Language).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Discount).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.Rating).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.IsCertificate).IsRequired();

        builder.HasOne(x => x.Level).WithMany(x => x.Courses).HasForeignKey(x => x.LevelId);
        builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey(x => x.CategoryId);
    }
}
