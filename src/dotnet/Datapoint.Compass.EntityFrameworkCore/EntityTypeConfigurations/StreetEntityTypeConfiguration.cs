using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class StreetEntityTypeConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
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

            builder.Property(e => e.StreetCode)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasKey(e => new
            {
                e.CountryCode,
                e.DistrictCode,
                e.CountyCode,
                e.LocalityCode,
                e.PostalCode,
                e.StreetCode
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

            builder.HasOne<Zone>()
                .WithMany()
                .HasForeignKey(e => new { e.CountryCode, e.DistrictCode, e.CountyCode, e.LocalityCode, e.PostalCode })
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
