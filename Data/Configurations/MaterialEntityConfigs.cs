using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

internal class MaterialEntityConfigs : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Url).IsRequired().HasMaxLength(1024);
        builder.Property(x => x.Duration).IsRequired(false);

        builder.HasOne(x => x.Lecture).WithMany(x => x.Materials).HasForeignKey(x => x.LectureId);
    }
}
