using Datapoint.Compass.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Datapoint.Compass.Migrator
{
    internal static class Program
    {
        internal static async Task Main(string[] args)
        {
            using var host = new HostBuilder()

                .ConfigureHostConfiguration((hostConfiguration) =>
                {
                    hostConfiguration.AddCommandLine(args);
                    hostConfiguration.AddEnvironmentVariables("ASPNETCORE_");
                    hostConfiguration.AddEnvironmentVariables("COMPASS_");
                })

                .UseContentRoot(Directory.GetCurrentDirectory())

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ProgramMigration>();

                    services.AddDbContext<CompassContext>((compass) =>
                    {
                        var connectionString = hostContext.Configuration.GetConnectionString("Compass");

                        if (string.IsNullOrEmpty(connectionString))
                        {
                            if (!hostContext.HostingEnvironment.IsDevelopment())
                                throw new InvalidOperationException("Compass connection string must be set for this environment.");

                            connectionString = "Server=127.0.0.1; Port=3306; Database=Compass; Uid=compass-migrator-app; Pwd=9d67330f-2df4-4174-a7b7-a5440acfd967";
                        }

                        compass.UseMySQL(connectionString, (mysql) =>
                        {
                            mysql.EnableRetryOnFailure();
                            mysql.MigrationsAssembly("Datapoint.Compass.Migrator");
                        });
                    });

                    services.AddLogging((logging) =>
                    {
                        logging.AddConsole();
                    });
                })

                .Build();

            if (EF.IsDesignTime)
                return;

            await host.StartAsync();
            await host.StopAsync();
        }
    }
}
