using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.Code);

            builder.HasAlternateKey(e => e.CodeA3);

            builder.HasAlternateKey(e => e.CodeN3);

            builder.Property(e => e.Code)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(e => e.CodeA3)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.CodeN3)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Nationality)
                .HasMaxLength(64)
                .IsRequired();
        }
    }
}
