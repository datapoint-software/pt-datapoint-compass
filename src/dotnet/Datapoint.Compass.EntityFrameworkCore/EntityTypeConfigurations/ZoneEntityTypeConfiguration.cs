using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class ZoneEntityTypeConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
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

            builder.Property(e => e.LocalityCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasKey(e => new
            {
                e.CountryCode,
                e.DistrictCode,
                e.CountyCode,
                e.LocalityCode,
                e.PostalCode
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

            builder.HasOne<County>()
                .WithMany()
                .HasForeignKey(e => new { e.CountryCode, e.DistrictCode, e.CountyCode })
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne<Locality>()
                .WithMany()
                .HasForeignKey(e => new { e.CountryCode, e.DistrictCode, e.CountyCode, e.LocalityCode })
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
