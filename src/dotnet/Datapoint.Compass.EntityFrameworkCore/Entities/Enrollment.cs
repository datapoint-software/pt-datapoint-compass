using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid RowVersionId { get; set; } = default!;

        public Facility Facility { get; set; } = default!;

        public Guid FacilityId { get; internal set; } = default!;

        public Service Service { get; set; } = default!;

        public Guid ServiceId { get; internal set; } = default!;

        public string Number { get; set; } = default!;

        public DateTimeOffset Creation { get; set; } = default!;

        public DateTimeOffset? Start { get; set; } = default!;
    }
}
