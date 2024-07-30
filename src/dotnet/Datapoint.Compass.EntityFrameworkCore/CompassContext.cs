using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datapoint.Compass.EntityFrameworkCore
{
    public sealed class CompassContext : DbContext
    {
        public CompassContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeRole> EmployeeRoles => Set<EmployeeRole>();

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<EmployeeSession> EmployeeSessions => Set<EmployeeSession>();

        public DbSet<Facility> Facilities => Set<Facility>();

        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

        public DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompassContext).Assembly);
        }
    }
}
