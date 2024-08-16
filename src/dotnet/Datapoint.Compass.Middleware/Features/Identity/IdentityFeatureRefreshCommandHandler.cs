using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeatureRefreshCommandHandler : ICommandHandler<IdentityFeatureRefreshCommand, IdentityFeature>
    {
        private static IdentityFeature Anonymous = new (
            null,
            null,
            null,
            null,
            IdentityKind.Anonymous,
            [],
            null);

        private readonly IMemoryCache _memoryCache;

        private readonly CompassContext _compass;

        public IdentityFeatureRefreshCommandHandler(IMemoryCache memoryCache, CompassContext compass)
        {
            _memoryCache = memoryCache;
            _compass = compass;
        }

        public async Task<IdentityFeature> HandleCommandAsync(IdentityFeatureRefreshCommand command, CancellationToken ct)
        {
            if (command.IdentityKind is IdentityKind.Anonymous)
                return Anonymous;

            Assert.NotNull(command.IdentitySessionId);

            return command.IdentityKind switch
            {
                IdentityKind.Employee => await EmployeeRefreshAsync(command, command.IdentitySessionId.Value, ct),
                _ => throw new NotImplementedException("Identity kind is not supported.")
            };
        }

        private async Task<IdentityFeature> EmployeeRefreshAsync(IdentityFeatureRefreshCommand command, Guid employeeSessionId, CancellationToken ct)
        {
            var employeeSession = await _compass.EmployeeSessions
                .Include(es => es.Employee)
                .Where(es => es.Id == employeeSessionId)
                .FirstOrDefaultAsync(ct);

            if (employeeSession is null)
                return Anonymous;

            var permissions = await _compass.GetEmployeePermissionsAsync(
                employeeSession.EmployeeId,
                ct);

            if (employeeSession.Expiration.HasValue)
                employeeSession.Expiration = command.Creation.AddMinutes(
                    await _compass.GetUserSessionExpirationAsync(
                        _memoryCache,
                        ct));

            return new IdentityFeature(
                employeeSession.Employee.Id,
                employeeSession.Id,
                employeeSession.Employee.Name,
                employeeSession.Employee.EmailAddress,
                IdentityKind.Employee,
                permissions,
                employeeSession.Expiration);
        }
    }
}
