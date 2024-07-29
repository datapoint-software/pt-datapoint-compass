using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Identities;
using System;
using System.Linq;
using System.Security.Claims;

namespace Datapoint.Compass.Api.Helpers
{
    internal static class ClaimsPrincipalHelper
    {
        internal static ClaimsPrincipal BuildClaimsPrincipal(Identity identity)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.Sid, identity.SessionId.ToString()),
                new(ClaimTypes.Name, identity.Name),
                new(ClaimTypes.NameIdentifier, identity.Id.ToString()),
                new(ClaimTypes.Email, identity.EmailAddress)
            }
                .Union(identity.Permissions.Select(p =>
                    new Claim(ClaimTypes.Role, p.ToString("G"))))

                .ToList();

            if (identity.Expiration.HasValue)
                claims.Add(new(ClaimTypes.Expiration, string.Concat(identity.Expiration.Value.UtcDateTime.ToString("s"), "Z")));

            claims.Add(new Claim(ClaimTypes.Authentication, identity.Kind switch
            {
                IdentityKind.Employee => "Employee",
                _ => throw new InvalidOperationException("Identity kind is not supported.")
            }));

            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    claims,
                    identity.Kind switch
                    {
                        IdentityKind.Employee => "Employee",
                        _ => throw new InvalidOperationException("Identity kind is not supported.")
                    },
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
