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
        private readonly ISeedDocumentoElasticRepository _documentoRepository;
        private readonly ISeedPessoaPFElasticRepository _pessoaPFRepository;
        private readonly ISeedDatabaseServices _services;

        public SeedDatabaseElasticSearchServices(
            ILogger<SeedDatabaseElasticSearchServices> logger,
            ISeedPessoaElasticRepository pessoaRepository,
            ISeedPessoaPFElasticRepository pessoaPFRepository,
            ISeedDocumentoElasticRepository documentoRepository,
            ISeedDatabaseServices services)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            _pessoaPFRepository = pessoaPFRepository;
            _documentoRepository = documentoRepository;
            _services = services;
        }

        public async Task InsertDocuments(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de documentos no ElasticSearch {time}", DateTime.UtcNow);

                var documents = _services.BuildDocumentList(quantity);

                await _documentoRepository.SeedData(documents);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} seconds", stopwatch.ElapsedMilliseconds / 1000);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task InsertPersons(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas no ElasticSearch {time}", DateTime.UtcNow);

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

        public async Task InsertPersonsPF(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas no ElasticSearch {time}", DateTime.UtcNow);

                var persons = _services.BuildPersonPFList(quantity);

                await _pessoaPFRepository.SeedData(persons);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} seconds", stopwatch.ElapsedMilliseconds / 1000);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}