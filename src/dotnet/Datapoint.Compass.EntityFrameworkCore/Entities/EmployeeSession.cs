using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class EmployeeSession
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Employee Employee { get; set; } = default!;

        internal Guid EmployeeId { get; set; } = default!;

        public DateTimeOffset? Expiration { get; set; } = default!;

        public string RemoteAddress { get; set; } = default!;

        public string UserAgent { get; set; } = default!;
    }
}
