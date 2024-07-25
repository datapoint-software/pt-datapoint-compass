using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Datapoint.Compass
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var hostConfiguration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables("ASPNETCORE_")
                .AddEnvironmentVariables("COMPASS_")
                .Build();

            new WebHostBuilder()
                .UseConfiguration(hostConfiguration)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()

                .Configure((hostContext, app) =>
                {
                    app.UseRouting();

                    app.UseEndpoints((endpoints) =>
                    {
                        endpoints.MapFallbackToFile("index.html");
                    });
                })

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddRouting();
                })

                .Build()
                .Run();
        }
    }
}