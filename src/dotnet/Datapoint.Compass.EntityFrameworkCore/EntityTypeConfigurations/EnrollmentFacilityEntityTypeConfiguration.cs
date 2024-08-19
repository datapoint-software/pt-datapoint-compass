using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class EnrollmentFacilityEntityTypeConfiguration : IEntityTypeConfiguration<EnrollmentFacility>
    {
        public void Configure(EntityTypeBuilder<EnrollmentFacility> builder)
        {
            builder.Property(e => e.EnrollmentId)
                .IsRequired();

            builder.Property(e => e.FacilityId)
                .IsRequired();

            builder.Property(e => e.Priority)
                .IsRequired();

            builder.HasKey(e => new { e.EnrollmentId, e.FacilityId });

            builder.HasOne(e => e.Enrollment)
                .WithMany()
                .HasForeignKey(e => e.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.Facility)
                .WithMany()
                .HasForeignKey(e => e.FacilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
