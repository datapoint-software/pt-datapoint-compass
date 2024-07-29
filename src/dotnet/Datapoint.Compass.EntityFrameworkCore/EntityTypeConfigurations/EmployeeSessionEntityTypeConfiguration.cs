using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class EmployeeSessionEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeSession>
    {
        public void Configure(EntityTypeBuilder<EmployeeSession> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.EmployeeId)
                .IsRequired();

            builder.Property(e => e.Expiration);

            builder.Property(e => e.RemoteAddress)
                .IsRequired();

            builder.Property(e => e.UserAgent)
                .HasMaxLength(4096)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
