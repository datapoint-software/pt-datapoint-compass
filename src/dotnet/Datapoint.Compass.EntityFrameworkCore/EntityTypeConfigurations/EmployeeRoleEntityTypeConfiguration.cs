using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class EmployeeRoleEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.Property(e => e.EmployeeId)
                .IsRequired();

            builder.Property(e => e.RoleId)
                .IsRequired();

            builder.HasKey(e => new { e.EmployeeId, e.RoleId });

            builder.HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
