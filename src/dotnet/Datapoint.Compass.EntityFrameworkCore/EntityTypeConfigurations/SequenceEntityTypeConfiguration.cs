using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class SequenceEntityTypeConfiguration : IEntityTypeConfiguration<Sequence>
    {
        public void Configure(EntityTypeBuilder<Sequence> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.RowVersionId)
                .IsConcurrencyToken()
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(4096);

            builder.Property(e => e.NextValue)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Name);
        }
    }
}
