using System;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class EmployeeSession
    {
        public Guid Id { get; set; } = default!;

        public Employee Employee { get; set; } = default!;

        public Guid EmployeeId { get; internal set; } = default!;

        public string RemoteAddress { get; set; } = default!;

        public string UserAgent { get; set; } = default!;

        public DateTimeOffset Creation { get; set; } = default!;

        public DateTimeOffset? Expiration { get; set; } = default!;
    }
}
