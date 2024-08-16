using Datapoint.Compass.Middleware.Features.Identity;
using Datapoint.Mediator;
using Datapoint.Mediator.FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Datapoint.Compass.Middleware
{
    public static class MiddlewareServiceCollectionExtensions
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services) => services

            .AddMediator((mediator) =>
            {
                mediator.AddHandlersFromAssemblyOf<IdentityFeatureRefreshCommandHandler>();

                mediator.AddFluentValidationMiddleware((fluentValidation) =>
                {
                    fluentValidation.AddValidatorsFromAssemblyOf<IdentityFeatureRefreshCommandValidator>();
                });

                mediator.AddMiddleware<CompassContextMiddleware>();
            });
    }
}
