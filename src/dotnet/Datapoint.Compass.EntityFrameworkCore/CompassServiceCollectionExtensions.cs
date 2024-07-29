using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Datapoint.Compass.EntityFrameworkCore
{
    public static class CompassServiceCollectionExtensions
    {
        public static IServiceCollection AddCompassContext(this IServiceCollection services, Action<DbContextOptionsBuilder> configure) =>

            services.AddDbContextFactory<CompassContext>(configure);
    }
}
