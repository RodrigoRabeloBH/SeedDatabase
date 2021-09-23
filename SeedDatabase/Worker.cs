using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Services;

namespace SeedDatabase
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IApplicationServices _services;
        private readonly IDapperPessoaServices _dapperServices;
        public Worker(ILogger<Worker> logger, IApplicationServices services, IDapperPessoaServices dapperServices)
        {
            _logger = logger;
            _services = services;
            _dapperServices = dapperServices;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cts = new CancellationTokenSource();

            while (!cts.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _dapperServices.InsertPessoaParallelSqlDapperTeste(1_000_000);

                var pessoas = await _dapperServices.SelectPessoasDapperTeste();

                _dapperServices.UpdatePessoasParallelDapperTeste(pessoas);

                cts.Cancel();

                _logger.LogInformation("Worker finished at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
