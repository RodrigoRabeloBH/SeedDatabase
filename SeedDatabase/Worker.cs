using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISeedDatabaseServices _services;
        private readonly IPessoaRepository _rep;

        public Worker(ILogger<Worker> logger, ISeedDatabaseServices services, IPessoaRepository rep)
        {
            _logger = logger;
            _services = services;
            _rep = rep;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var persons = _services.BuildPersonList(1000000);

                await _rep.SeedData(persons);

                _logger.LogInformation("Worker finished at: {time}", DateTimeOffset.Now);                

                await Task.Delay(1000 * 60 * 10, stoppingToken);
            }
        }
    }
}
