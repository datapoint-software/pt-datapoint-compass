using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Facility
    {
        public Guid Id { get; set; } = default!;

        public Guid RowVersionId { get; set; } = default!;

        public string Code { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Description { get; set; } = default!;
    }
}
