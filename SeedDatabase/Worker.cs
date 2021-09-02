using System;
using System.Diagnostics;
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
            int i = 0;

            while (!stoppingToken.IsCancellationRequested && i != 1)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var persons = _services.BuildPersonList(1000000);

                await _rep.SeedData(persons);

                stopwatch.Stop();

                _logger.LogInformation("Worker finished at: {time} minutes", stopwatch.ElapsedMilliseconds / 60000);

                i = 1;

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
