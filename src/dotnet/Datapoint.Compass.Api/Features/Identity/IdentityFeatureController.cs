using Datapoint.Compass.Api.Helpers;
using Datapoint.Compass.Enumerations;
using Datapoint.Compass.Middleware.Features.Identity;
using Datapoint.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Api.Features.Identity
{
    [Route("/api/features/identity")]
    public sealed class IdentityFeatureController : Controller
    {
        private readonly IMediator _mediator;

        public IdentityFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IdentityFeatureModel> RefreshAsync(CancellationToken ct)
        {
            var authenticated = User.Identity?.IsAuthenticated ?? false;

            var result = await _mediator.HandleCommandAsync<IdentityFeatureRefreshCommand, IdentityFeature>(
                new IdentityFeatureRefreshCommand(
                    (authenticated ? User.GetKind() : IdentityKind.Anonymous),
                    (authenticated ? User.GetSessionId() : null)),
                ct);

            if (result.Kind is not IdentityKind.Anonymous)
                await HttpContext.SignInAsync(result);

            return new IdentityFeatureModel(
                result.Id,
                result.Name,
                result.EmailAddress,
                result.Kind,
                result.Permissions,
                result.Expiration);
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IdentityFeatureModel> SignInAsync([FromBody] IdentityFeatureSignInModel model, CancellationToken ct)
        {
            var result = await _mediator.HandleCommandAsync<IdentityFeatureSignInCommand, IdentityFeature>(
                new IdentityFeatureSignInCommand(
                    HttpContext.GetRemoteAddress(),
                    HttpContext.GetUserAgent(),
                    model.EmailAddress,
                    model.Password,
                    model.RememberMe),
                ct);

            if (result.Kind is not IdentityKind.Anonymous)
                await HttpContext.SignInAsync(result);

            return new IdentityFeatureModel(
                result.Id,
                result.Name,
                result.EmailAddress,
                result.Kind,
                result.Permissions,
                result.Expiration);
        }
    }
}
