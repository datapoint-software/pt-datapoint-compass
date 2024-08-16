using Datapoint.Compass.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class ParameterHelper
    {
        internal static async Task<int> GetUserSessionExpirationAsync(this DbSet<Parameter> parameters, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(parameters, memoryCache, "UserSessionExpiration", ct)) ?? 45;

        internal static async Task<int> GetUserPasswordHashWorkFactorAsync(this DbSet<Parameter> parameters, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(parameters, memoryCache, "UserPasswordHashWorkFactor", ct)) ?? 8;

        internal static async Task<int> GetUserPasswordHashTimeSpanAsync(this DbSet<Parameter> parameters, IMemoryCache memoryCache, CancellationToken ct) =>

            (await GetValueOrDefault<int?>(parameters, memoryCache, "UserPasswordHashTimeSpan", ct)) ?? 1500;

        internal static Task<T?> GetValueOrDefault<T>(this DbSet<Parameter> parameters, IMemoryCache memoryCache, string parameterName, CancellationToken ct)
        {
            var ck = $"parameters/{parameterName}/?type={typeof(T).FullName ?? typeof(T).Name}";

            return memoryCache.GetOrCreateAsync(ck, async (_) =>
            {
                var parameter = await parameters
                    .Where(p => p.Name == parameterName)
                    .FirstOrDefaultAsync(ct);

                if (parameter is null)
                    return default;

                return JsonSerializer.Deserialize<T>(parameter.JsonValue);
            });
        }
    }
}
