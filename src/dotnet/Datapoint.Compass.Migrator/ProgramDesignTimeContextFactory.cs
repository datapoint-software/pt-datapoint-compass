using Datapoint.Compass.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Datapoint.Compass.Migrator
{
    internal sealed class ProgramDesignTimeContextFactory : IDesignTimeDbContextFactory<CompassContext>
    {
        public CompassContext CreateDbContext(string[] args)
        {
            var hostConfiguration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables("ASPNETCORE_")
                .AddEnvironmentVariables("COMPASS_")
                .Build();

            var connectionString = hostConfiguration.GetConnectionString("Compass");

            if (string.IsNullOrEmpty(connectionString))
            {
                var environmentName = hostConfiguration.GetValue<string>("Environment");

                if (string.IsNullOrEmpty(environmentName) || !environmentName.Equals("Development", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("Compass connection string must be set for this environment.");

                connectionString = "Server=127.0.0.1; Port=3306; Database=Compass; Uid=compass-migrator-app; Pwd=9d67330f-2df4-4174-a7b7-a5440acfd967";
            }

            var compassContextOptions = new DbContextOptionsBuilder()

                .UseMySQL(connectionString, (mysql) =>
                {
                    mysql.EnableRetryOnFailure();
                    mysql.MigrationsAssembly("Datapoint.Compass.Migrator");
                })

                .Options;

            return new CompassContext(compassContextOptions);
        }
    }
}
