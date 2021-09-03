using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISeedDatabaseMongoDBServices _mongoServices;
        private readonly ISeedDatabaseSQLServerServices _sqlServerServices;
        public Worker(ILogger<Worker> logger,
                      ISeedDatabaseMongoDBServices mongoServices,
                      ISeedDatabaseSQLServerServices sqlServerServices)
        {
            _logger = logger;
            _mongoServices = mongoServices;
            _sqlServerServices = sqlServerServices;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;

            while (!stoppingToken.IsCancellationRequested && i != 1)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _mongoServices.InsertPersons(1000);

                i = 1;

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
