using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TestPostgres
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(r => r.RegionId);

            builder.Property(r => r.RegionName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(r => r.School)
                   .WithOne(s => s.Region)
                   .HasForeignKey(s => s.RegionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
