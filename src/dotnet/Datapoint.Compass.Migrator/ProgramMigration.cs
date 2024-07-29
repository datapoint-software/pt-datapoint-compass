using Datapoint.Compass.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Migrator
{
    internal sealed class ProgramMigration : IHostedService
    {
        private readonly ILogger<ProgramMigration> _logger;

        private readonly CompassContext _compass;

        public ProgramMigration(ILogger<ProgramMigration> logger, CompassContext compass)
        {
            _logger = logger;
            _compass = compass;
        }

        public async Task StartAsync(CancellationToken ct)
        {
            var migrations = (await _compass.Database.GetPendingMigrationsAsync(ct)).ToList();

            if (migrations.Count > 0)
            {
                foreach (var migration in migrations)
                    _logger.LogInformation("Migration: {Migration}", migration);

                await _compass.Database.MigrateAsync(ct);
            }
        }

        public Task StopAsync(CancellationToken ct) =>

            Task.CompletedTask;
    }
}