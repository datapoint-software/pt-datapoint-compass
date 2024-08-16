using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class EmployeeRole
    {
        public Employee Employee { get; set; } = default!;

        public Guid EmployeeId { get; internal set; } = default!;

        public Role Role { get; set; } = default!;

        public Guid RoleId { get; internal set; } = default!;
    }
}
