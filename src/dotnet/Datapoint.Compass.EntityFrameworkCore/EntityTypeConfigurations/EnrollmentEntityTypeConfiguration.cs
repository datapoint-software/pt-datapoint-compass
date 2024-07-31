using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.RowVersionId)
                .IsConcurrencyToken()
                .IsRequired();

            builder.Property(e => e.Number)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.Creation)
                .IsRequired();

            builder.Property(e => e.Start);

            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Number);

            builder.HasOne(e => e.Facility)
                .WithMany()
                .HasForeignKey(e => e.FacilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.Service)
                .WithMany()
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
