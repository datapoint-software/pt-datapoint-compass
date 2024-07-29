using Datapoint.Compass.Api.Helpers;
using Datapoint.Compass.Middleware.Identities;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Identities
{
    [Route("/api/identities")]
    public sealed class IdentityController : Controller
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator) =>
            _mediator = mediator;

        [Authorize]
        [HttpPost("refresh")]
        public async Task<IdentityModel> RefreshAsync(CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<IdentityRefreshCommand, Identity>(
                new IdentityRefreshCommand(
                    User.GetSessionId(),
                    User.GetKind(),
                    User.GetExpiration()),
                ct);

            await HttpContext.SignInAsync(
                ClaimsPrincipalHelper.BuildClaimsPrincipal(result),
                new() { ExpiresUtc = result.Expiration });

            return new IdentityModel(
                result.Id,
                result.Name,
                result.EmailAddress,
                result.Kind,
                result.Permissions,
                result.Expiration);
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IdentityModel> SignInAsync([FromBody] IdentitySignInModel model, CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<IdentitySignInCommand, Identity>(
                new IdentitySignInCommand(
                    HttpContext.GetRemoteAddress(),
                    HttpContext.GetUserAgent(),
                    model.EmailAddress,
                    model.Password,
                    model.RememberMe),
                ct);

            await HttpContext.SignInAsync(
                ClaimsPrincipalHelper.BuildClaimsPrincipal(result),
                new () { ExpiresUtc = result.Expiration });

            return new IdentityModel(
                result.Id,
                result.Name,
                result.EmailAddress,
                result.Kind,
                result.Permissions,
                result.Expiration);
        }

        [Authorize]
        [HttpPost("sign-out")]
        public Task SignOutAsync() => HttpContext.SignOutAsync();

    }
}
