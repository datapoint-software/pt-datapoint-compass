using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class CompassContextHelper
    {
        // #region Settings

        internal static async Task<string> GetCountryCodeAsync(this CompassContext compass, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<string?>(compass, memoryCache, "CountryCode", ct)) ?? "US";

        internal static async Task<string?> GetDistrictCodeAsync(this CompassContext compass, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<string?>(compass, memoryCache, "DistrictCode", ct));

        internal static async Task<int> GetUserSessionExpirationAsync(this CompassContext compass, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(compass, memoryCache, "UserSessionExpiration", ct)) ?? 45;

        internal static async Task<int> GetUserPasswordHashWorkFactorAsync(this CompassContext compass, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(compass, memoryCache, "UserPasswordHashWorkFactor", ct)) ?? 8;

        internal static async Task<int> GetUserPasswordHashTimeSpanAsync(this CompassContext compass, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(compass, memoryCache, "UserPasswordHashTimeSpan", ct)) ?? 1500;

        // #endregion

        internal static async Task<IEnumerable<Permission>> GetEmployeePermissionsAsync(this CompassContext compass, Guid employeeId, CancellationToken ct) =>

            await compass.EmployeeRoles
                .AsNoTracking()
                .Where(er => er.EmployeeId == employeeId)
                .SelectMany(er => er.Role.Permissions)
                .Select(rp => rp.Permission)
                .Distinct()
                .ToListAsync(ct);

        internal static Task<T?> GetValueOrDefault<T>(this CompassContext compass, IMemoryCache memoryCache, string parameterName, CancellationToken ct)
        {
            var ck = $"parameters/{parameterName}/?type={typeof(T).FullName ?? typeof(T).Name}";

            return memoryCache.GetOrCreateAsync(ck, async (_) =>
            {
                var parameter = await compass.Parameters
                    .Where(p => p.Name == parameterName)
                    .FirstOrDefaultAsync(ct);

                if (parameter is null)
                    return default;

                return JsonSerializer.Deserialize<T>(parameter.JsonValue);
            });
        }
    }
}
