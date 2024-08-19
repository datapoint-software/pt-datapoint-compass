using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datapoint.Compass.EntityFrameworkCore
{
    public sealed class CompassContext : DbContext
    {
        public CompassContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<District> Districts => Set<District>();

        public DbSet<EmployeeRole> EmployeeRoles => Set<EmployeeRole>();

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<EmployeeSession> EmployeeSessions => Set<EmployeeSession>();

        public DbSet<EnrollmentFacility> EnrollmentFacilities => Set<EnrollmentFacility>();

        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        public DbSet<Facility> Facilities => Set<Facility>();

        public DbSet<Parameter> Parameters => Set<Parameter>();

        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<Sequence> Sequences => Set<Sequence>();

        public DbSet<Service> Services => Set<Service>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompassContext).Assembly);
        }
    }
}
