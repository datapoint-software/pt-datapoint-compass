using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class CountyEntityTypeConfiguration : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.Property(e => e.CountryCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.DistrictCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.CountyCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasKey(e => new
            {
                e.CountryCode,
                e.DistrictCode,
                e.CountyCode
            });

            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(e => e.CountryCode)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne<District>()
                .WithMany()
                .HasForeignKey(e => new { e.CountryCode, e.DistrictCode })
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
