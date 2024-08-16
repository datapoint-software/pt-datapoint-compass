using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datapoint.Compass.EntityFrameworkCore.EntityTypeConfigurations
{
    public sealed class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.RowVersionId)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.EmailAddress)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.EmailAddress)
                .IsUnique();
        }
    }
}
