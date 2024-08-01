using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class DistrictEntityTypeConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(e => e.Code)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasKey(e => new { e.CountryCode, e.Code });

            builder.HasOne<Country>()
                .WithMany()
                .HasForeignKey(e => e.CountryCode)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
