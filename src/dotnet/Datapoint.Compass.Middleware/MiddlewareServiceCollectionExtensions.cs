using Datapoint.Compass.Middleware.Identities;
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
                mediator.AddHandlersFromAssemblyOf<IdentitySignInCommandHandler>();

                mediator.AddFluentValidationMiddleware((fluentValidation) =>
                {
                    fluentValidation.AddValidatorsFromAssemblyOf<IdentitySignInCommandValidator>();
                });

                mediator.AddMiddleware<CompassContextMiddleware>();
            });
    }
}
