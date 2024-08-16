using System;
using System.Collections.Generic;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Role
    {
        public Guid Id { get; set; } = default!;

        public Guid RowVersionId { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Description { get; set; } = default!;

        public IEnumerable<RolePermission> Permissions { get; set; } = default!;
    }
}
