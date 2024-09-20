using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TestPostgres
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(s => s.SchoolId);

            builder.Property(s => s.SchoolName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(s => s.Region)
                   .WithMany(r => r.School)
                   .HasForeignKey(s => s.RegionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
