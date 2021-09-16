using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeedDatabase.Services;

namespace SeedDatabase
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IApplicationServices _services;
        public Worker(ILogger<Worker> logger, IApplicationServices services)
        {
            _logger = logger;
            _services = services;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;

            while (!stoppingToken.IsCancellationRequested && i != 1)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _services.RunMongoTest(1000000);

                // await _services.RunSQLServerTest(1000000);

                i = 1;

                _logger.LogInformation("Worker finished at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
