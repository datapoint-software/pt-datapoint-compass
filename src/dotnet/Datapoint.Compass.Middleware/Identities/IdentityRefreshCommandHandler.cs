using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Identities
{
    public sealed class IdentityRefreshCommandHandler : ICommandHandler<IdentityRefreshCommand, Identity>
    {
        private readonly CompassContext _compass;

        public IdentityRefreshCommandHandler(CompassContext compass) =>
            _compass = compass;

        public Task<Identity> HandleCommandAsync(IdentityRefreshCommand command, CancellationToken ct)
        {
            return command.IdentityKind switch
            {
                IdentityKind.Employee => RefreshEmployeeAsync(command, ct),
                _ => throw new InvalidOperationException("Identity kind is not supported.")
            };
        }

        private async Task<Identity> RefreshEmployeeAsync(IdentityRefreshCommand command, CancellationToken ct)
        {
            var employeeSession = await _compass.EmployeeSessions
                .Include(es => es.Employee)
                .Where(es => es.Id == command.IdentitySessionId)
                .FirstOrDefaultAsync(ct);

            if (employeeSession is null)
                throw new BusinessException("Employee session was not found.");

            if (employeeSession.Expiration.HasValue && command.Creation > employeeSession.Expiration)
                throw new BusinessException("Employee session has expired.");

            var permissions = await _compass.Entry(employeeSession.Employee)
                .Collection(e => e.Roles)
                .Query()
                .Select(e => e.Role)
                .SelectMany(e => e.Permissions)
                .Select(e => e.Permission)
                .Distinct()
                .ToListAsync(ct);

            permissions.Add(Permission.Workspace);

            if (employeeSession.Expiration.HasValue)
                employeeSession.Expiration = command.Creation.AddMinutes(45);

            return new Identity(
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
