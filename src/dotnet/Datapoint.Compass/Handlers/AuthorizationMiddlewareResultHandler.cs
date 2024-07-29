using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Datapoint.Compass.Handlers
{
    internal sealed class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        public Task HandleAsync(RequestDelegate next, HttpContext httpContext, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Succeeded)
                return next(httpContext);

            if (authorizeResult.Challenged)
                throw new AuthenticationException("Policy authorization result is challanged.");

            if (authorizeResult.Forbidden)
                throw new AuthorizationException("Policy authorization result is forbidden.");

            throw new InvalidOperationException("Policy authorization result state is unsupported.");
        }
    }
}
