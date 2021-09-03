using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Services
{
    public class SeedDatabaseElasticSearchServices : ISeedDatabaseElasticSearchServices
    {
        private readonly ILogger<SeedDatabaseElasticSearchServices> _logger;
        private readonly ISeedPessoaElasticRepository _pessoaRepository;
        private readonly ISeedDatabaseServices _services;

        public SeedDatabaseElasticSearchServices(ILogger<SeedDatabaseElasticSearchServices> logger,
                                                 ISeedPessoaElasticRepository pessoaRepository, ISeedDatabaseServices services)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            _services = services;
        }

        public Task InsertDocuments(int quantity)
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertPersons(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas no MongoDB {time}", DateTime.UtcNow);

                var persons = _services.BuildPersonList(quantity);

                await _pessoaRepository.SeedData(persons);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} seconds", stopwatch.ElapsedMilliseconds / 1000);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public Task InsertPersonsPF(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}