using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class CompassContextHelper
    {
        internal static async Task<IEnumerable<Permission>> GetEmployeePermissionsAsync(this CompassContext compass, Guid employeeId, CancellationToken ct) =>

            await compass.EmployeeRoles
                .AsNoTracking()
                .Where(er => er.EmployeeId == employeeId)
                .SelectMany(er => er.Role.Permissions)
                .Select(rp => rp.Permission)
                .Distinct()
                .ToListAsync(ct);
    }
}
