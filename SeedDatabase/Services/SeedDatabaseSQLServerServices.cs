using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Services
{
    public class SeedDatabaseSQLServerServices : ISeedDatabaseSQLServerServices
    {
        private readonly ILogger<SeedDatabaseSQLServerServices> _logger;
        private readonly ISeedDatabaseServices _services;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaPFRepository _pessoaPFRepository;
        private readonly IDocumentoRepository _documentoRepository;

        public SeedDatabaseSQLServerServices(ILogger<SeedDatabaseSQLServerServices> logger, ISeedDatabaseServices services,
                                             IPessoaRepository pessoaRepository, IPessoaPFRepository pessoaPFRepository,
                                             IDocumentoRepository documentoRepository)
        {
            _logger = logger;
            _services = services;
            _pessoaRepository = pessoaRepository;
            _pessoaPFRepository = pessoaPFRepository;
            _documentoRepository = documentoRepository;
        }

        public async Task InsertPersons(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas no SQL Server {time}", DateTime.UtcNow);

                var pessoas = _services.BuildPersonList(quantity);

                await _pessoaRepository.SeedData(pessoas);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as: {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} segundos", stopwatch.ElapsedMilliseconds / 1000);

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

                _logger.LogInformation("Inicio de insert de pessoas PF no SQL Server {time}", DateTime.UtcNow);

                var pessoas = _services.BuildPersonPFList(quantity);

                await _pessoaPFRepository.SeedData(pessoas);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as: {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} segundos", stopwatch.ElapsedMilliseconds / 1000);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task InsertDocuments(int quantity)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                _logger.LogInformation("Inicio de insert de pessoas PF no SQL Server {time}", DateTime.UtcNow);

                var documentos = _services.BuildDocuemntList(quantity);

                await _documentoRepository.SeedData(documentos);

                stopwatch.Stop();

                _logger.LogInformation("Fim do processo as: {time}", DateTime.UtcNow);

                _logger.LogInformation("Tempo decorrido do processo: {time} segundos", stopwatch.ElapsedMilliseconds / 1000);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}