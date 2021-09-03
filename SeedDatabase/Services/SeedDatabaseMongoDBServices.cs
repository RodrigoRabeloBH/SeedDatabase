using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Services
{
    public class SeedDatabaseMongoDBServices : ISeedDatabaseMongoDBServices
    {
        private readonly ILogger<SeedDatabaseMongoDBServices> _logger;
        private readonly ISeedPessoaMongoDBRepository _pessoaRepository;
        private readonly ISeedPessoaPFMongoDBRepository _pessoaPFRepository;
        private readonly ISeedDocumentoMongoDBRepository _documentoRepository;
        private readonly ISeedDatabaseServices _services;

        public SeedDatabaseMongoDBServices(ILogger<SeedDatabaseMongoDBServices> logger,
                                          ISeedPessoaMongoDBRepository pessoaRepository,
                                          ISeedPessoaPFMongoDBRepository pessoaPFRepository,
                                          ISeedDocumentoMongoDBRepository documentoMongoDBRepository,
                                          ISeedDatabaseServices services)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
            _pessoaPFRepository = pessoaPFRepository;
            _documentoRepository = documentoMongoDBRepository;
            _services = services;
        }

        public async Task InsertDocuments(int quantity)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            _logger.LogInformation("Inicio de insert de documentos no MongoDB {time}", DateTime.UtcNow);

            var documentos = _services.BuildDocumentList(quantity);

            await _documentoRepository.SeedData(documentos);

            stopwatch.Stop();

            _logger.LogInformation("Fim do processo as: {time}", DateTime.UtcNow);

            _logger.LogInformation("Tempo decorrido do processo: {time} segundos", stopwatch.ElapsedMilliseconds / 1000);
        }
        public async Task InsertPersons(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas no MongoDB {time}", DateTime.UtcNow);

                var pessoas = _services.BuildPersonList(quantity);

                await _pessoaRepository.SeedData(pessoas);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time}", stopwatch.ElapsedMilliseconds);

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

                _logger.LogInformation("Inicio de insert de pessoas físicas no MongoDB {time}", DateTime.UtcNow);

                var pessoasPF = _services.BuildPersonPFList(quantity);

                await _pessoaPFRepository.SeedData(pessoasPF);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time}", stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}