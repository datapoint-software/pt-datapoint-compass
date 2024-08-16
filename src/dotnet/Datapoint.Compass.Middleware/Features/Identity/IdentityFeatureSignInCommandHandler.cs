using Datapoint.Compass.EntityFrameworkCore;
using Datapoint.Compass.EntityFrameworkCore.Entities;
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
    public sealed class IdentityFeatureSignInCommandHandler : ICommandHandler<IdentityFeatureSignInCommand, IdentityFeature>
    {
        private const string GenericBusinessExceptionMessage = "A user was not found matching the given email address and password combination.";

        private readonly IMemoryCache _memoryCache;

        private readonly CompassContext _compass;

        public IdentityFeatureSignInCommandHandler(IMemoryCache memoryCache, CompassContext compass)
        {
            _memoryCache = memoryCache;
            _compass = compass;
        }

        public async Task<IdentityFeature> HandleCommandAsync(IdentityFeatureSignInCommand command, CancellationToken ct)
        {
            var timeSpan = await _compass.Parameters.GetUserPasswordHashTimeSpanAsync(
                _memoryCache,
                ct);

            var timeSpanTask = Task.Delay(timeSpan, ct);
            var signInTask = SignInAsync(command, ct);

            await Task.WhenAll(timeSpanTask, signInTask);

            return signInTask.Result;
        }

        private async Task<IdentityFeature> SignInAsync(IdentityFeatureSignInCommand command, CancellationToken ct)
        {
            var employee = await _compass.Employees
                .Where(e => e.EmailAddress == command.EmailAddress)
                .FirstOrDefaultAsync(ct);

            if (employee is not null)
                return await EmployeeSignInAsync(command, employee, ct);

            throw new BusinessException(GenericBusinessExceptionMessage);
        }

        private async Task<IdentityFeature> EmployeeSignInAsync(IdentityFeatureSignInCommand command, Employee employee, CancellationToken ct)
        {
            if (!PasswordHashHelper.VerifyPassword(command.Password, employee.PasswordHash))
                throw new BusinessException(GenericBusinessExceptionMessage);

            var userPasswordHashWorkFactor = await _compass.Parameters.GetUserPasswordHashWorkFactorAsync(
                _memoryCache,
                ct);

            if (!PasswordHashHelper.VerifyPasswordHash(employee.PasswordHash, userPasswordHashWorkFactor))
                employee.PasswordHash = PasswordHashHelper.ComputePasswordHash(command.Password, userPasswordHashWorkFactor);

            var permissions = await _compass.GetEmployeePermissionsAsync(
                employee.Id,
                ct);

            var employeeSession = _compass.EmployeeSessions.Add(new()
            {
                Id = Guid.NewGuid(),
                Employee = employee,
                RemoteAddress = command.RemoteAddress.ToString(),
                UserAgent = command.UserAgent,
                Creation = command.Creation,
                Expiration = command.RememberMe
                    ? null
                    : command.Creation.AddMinutes(
                        await _compass.Parameters.GetUserSessionExpirationAsync(
                            _memoryCache,
                            ct))
            })
                .Entity;

            return new IdentityFeature(
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
