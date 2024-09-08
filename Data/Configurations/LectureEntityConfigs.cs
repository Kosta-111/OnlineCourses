using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class LectureEntityConfigs : IEntityTypeConfiguration<Lecture>
{
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x => x.ImageUrl).IsRequired(false).HasMaxLength(1024);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(2000);

        builder.HasOne(x => x.Course).WithMany(x => x.Lectures).HasForeignKey(x => x.CourseId);
    }
}
