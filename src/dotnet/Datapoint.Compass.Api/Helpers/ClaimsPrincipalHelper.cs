using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Features.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Datapoint.Compass.Api.Helpers
{
    internal static class ClaimsPrincipalHelper
    {
        internal static ClaimsPrincipal BuildClaimsPrincipal(IdentityFeature identity) => identity.Kind switch
        {
            IdentityKind.Employee => BuildEmployeeClaimsPrincipal(
                identity.Id!.Value,
                identity.SessionId!.Value,
                identity.Name!,
                identity.EmailAddress!,
                identity.Permissions,
                identity.Expiration),

            _ => throw new NotImplementedException("Identity kind is not supported.")
        };

        private static ClaimsPrincipal BuildEmployeeClaimsPrincipal(Guid id, Guid sessionId, string name, string emailAddress, IEnumerable<Permission> permissions, DateTimeOffset? expiration)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.Authentication, "Employee"),
                new(ClaimTypes.Sid, sessionId.ToString()),
                new(ClaimTypes.Name, name),
                new(ClaimTypes.NameIdentifier, id.ToString()),
                new(ClaimTypes.Email, emailAddress)
            }
                .Union(permissions.Select(p =>
                    new Claim(ClaimTypes.Role, p.ToString("G"))))

                .ToList();

            if (expiration.HasValue)
                claims.Add(new(ClaimTypes.Expiration, string.Concat(expiration.Value.UtcDateTime.ToString("s"), "Z")));

            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    claims,
                    "Employee",
                    ClaimTypes.Name,
                    ClaimTypes.Role));
        }

        internal static Guid GetEmployeeId(this ClaimsPrincipal principal)
        {
            if (GetKind(principal) is not IdentityKind.Employee)
                throw new InvalidOperationException("Claims principal is not an employee.");

            return GetId(principal);
        }

        internal static DateTimeOffset? GetExpiration(this ClaimsPrincipal principal) =>

            principal.Claims
                .Where(c => c.Type.Equals(ClaimTypes.Expiration, StringComparison.Ordinal))
                .Select(c => c.Value)
                .Select(DateTimeOffset.Parse)
                .FirstOrDefault();

        internal static Guid GetId(this ClaimsPrincipal principal) =>

            principal.Claims
                .Where(c => c.Type.Equals(ClaimTypes.NameIdentifier, StringComparison.Ordinal))
                .Select(c => c.Value)
                .Select(Guid.Parse)
                .First();

        internal static IdentityKind GetKind(this ClaimsPrincipal principal) =>

            principal.Claims
                .Where(c => c.Type.Equals(ClaimTypes.Authentication, StringComparison.Ordinal))
                .Select(c => c.Value)
                .Select(a => a switch
                {
                    "Employee" => IdentityKind.Employee,
                    _ => throw new InvalidOperationException("Claims principal identity kind is not supported.")
                })
                .First();

        internal static Guid GetSessionId(this ClaimsPrincipal principal) =>

            principal.Claims
                .Where(c => c.Type.Equals(ClaimTypes.Sid, StringComparison.Ordinal))
                .Select(c => c.Value)
                .Select(Guid.Parse)
                .First();

        internal static bool HasPermission(this ClaimsPrincipal principal, Permission permission) =>

            principal.IsInRole(permission.ToString("G"));
    }
}
