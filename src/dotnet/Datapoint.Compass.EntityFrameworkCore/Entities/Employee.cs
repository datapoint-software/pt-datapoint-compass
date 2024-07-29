using System;
using System.Collections.Generic;

namespace Datapoint.Compass.EntityFrameworkCore.Entities
{
    public sealed class Employee
    {
        public Guid Id { get; set; } = default!;

        public Guid RowVersionId { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public string PasswordHash { get; set; } = default!;

        public List<EmployeeRole> Roles { get; internal set; } = default!;
    }
}
