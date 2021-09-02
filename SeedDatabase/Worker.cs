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
        private readonly IPessoaPFRepository _repPF;
        private readonly IDocumentoRepository _repDoc;

        public Worker(ILogger<Worker> logger, ISeedDatabaseServices services, IPessoaRepository rep, IPessoaPFRepository repPF, IDocumentoRepository repDoc)
        {
            _logger = logger;
            _services = services;
            _rep = rep;
            _repPF = repPF;
            _repDoc = repDoc;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;

            while (!stoppingToken.IsCancellationRequested && i != 1)
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // await InsertPersonPF(1000);

                await InsertDocuments(1000000);

                stopwatch.Stop();

                _logger.LogInformation("Worker finished at: {time} seconds", stopwatch.ElapsedMilliseconds / 1000);

                i = 1;

                await Task.Delay(1000, stoppingToken);
            }
        }
        private async Task InsertPerson(int qtd)
        {
            try
            {
                var persons = _services.BuildPersonList(qtd);

                await _rep.SeedData(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        private async Task InsertPersonPF(int qtd)
        {
            try
            {
                var persons = _services.BuildPersonPFList(qtd);

                await _repPF.SeedData(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        private async Task InsertDocuments(int qtd)
        {
            try
            {
                var documentos = _services.BuildDocuemntList(qtd);

                await _repDoc.SeedData(documentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
