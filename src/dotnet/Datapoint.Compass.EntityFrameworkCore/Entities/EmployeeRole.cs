using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class EmployeeRole
    {
        public Employee Employee { get; set; } = default!;

        internal Guid EmployeeId { get; set; } = default!;

        public Role Role { get; set; } = default!;

        internal Guid RoleId { get; set; } = default!;
    }
}
