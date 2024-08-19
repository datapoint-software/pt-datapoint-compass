using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class EnrollmentFacility
    {
        public Enrollment Enrollment { get; set; } = default!;

        public Guid EnrollmentId { get; internal set; } = default!;

        public Facility Facility { get; set; } = default!;

        public Guid FacilityId { get; internal set; } = default!;

        public int Priority { get; set; } = default!;
    }
}
