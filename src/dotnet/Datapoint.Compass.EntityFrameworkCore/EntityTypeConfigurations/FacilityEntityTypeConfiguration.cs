using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class FacilityEntityTypeConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.RowVersionId)
                .IsConcurrencyToken()
                .IsRequired();

            builder.Property(e => e.Code)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(4096);

            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Code);

            builder.HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
