using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Sequence
    {
        public Guid Id { get; set; } = default!;

        public Guid RowVersionId { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string? Description { get; set; } = default!;

        public int NextValue { get; set; } = default!;
    }
}
