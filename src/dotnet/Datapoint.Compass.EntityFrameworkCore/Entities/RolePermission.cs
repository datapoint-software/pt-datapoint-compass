using Datapoint.Compass.Enumerations;
using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class RolePermission
    {
        public Role Role { get; set; } = default!;

        internal Guid RoleId { get; set; } = default!;

        public Permission Permission { get; set; } = default!;
    }
}
