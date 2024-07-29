using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Helpers;
using Datapoint.Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Identities
{
    public sealed class IdentitySignInCommandHandler : ICommandHandler<IdentitySignInCommand, Identity>
    {
        private const string GenericBusinessExceptionMessage = "A user was not found matching this email and password combination.";

        private const int SignInMaximumTime = 1500;

        private const int UserPasswordHashWorkFactor = 8;

        private readonly CompassContext _compass;

        public IdentitySignInCommandHandler(CompassContext compass)
        {
            _compass = compass;
        }

        public async Task<Identity> HandleCommandAsync(IdentitySignInCommand command, CancellationToken ct)
        {
            var time = Task.Delay(SignInMaximumTime, ct);
            var signIn = SignInAsync(command, ct);

            await Task.WhenAll(time, signIn);

            return signIn.Result;
        }

        public async Task<Identity> SignInAsync(IdentitySignInCommand command, CancellationToken ct)
        {
            var employee = await _compass.Employees
                .Where(e => e.EmailAddress == command.EmailAddress)
                .FirstOrDefaultAsync(ct);

            if (employee is null)
                throw new BusinessException(GenericBusinessExceptionMessage);

            if (!UserPasswordHashHelper.VerifyPassword(command.Password, employee.PasswordHash))
                throw new BusinessException(GenericBusinessExceptionMessage);

            if (!UserPasswordHashHelper.VerifyPasswordHash(employee.PasswordHash, UserPasswordHashWorkFactor))
                employee.PasswordHash = UserPasswordHashHelper.ComputePasswordHash(command.Password, UserPasswordHashWorkFactor);

            var permissions = await _compass.Entry(employee)
                .Collection(e => e.Roles)
                .Query()
                .Select(e => e.Role)
                .SelectMany(e => e.Permissions)
                .Select(e => e.Permission)
                .Distinct()
                .ToListAsync(ct);

            permissions.Add(Permission.Workspace);

            var employeeSession = _compass.EmployeeSessions.Add(new()
            {
                Id = Guid.NewGuid(),
                Employee = employee,
                Expiration = command.RememberMe
                    ? null
                    : command.Creation.AddMinutes(15),
                RemoteAddress = command.RemoteAddress.ToString(),
                UserAgent = command.UserAgent,
            })
                .Entity;

            return new Identity(
                employee.Id,
                employeeSession.Id,
                employee.Name,
                employee.EmailAddress,
                IdentityKind.Employee,
                permissions,
                employeeSession.Expiration);
        }
    }
}
