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
        private readonly ISeedDatabaseServices _services;

        public SeedDatabaseMongoDBServices(ILogger<SeedDatabaseMongoDBServices> logger,
                                          ISeedPessoaMongoDBRepository pessoaRepository,
                                          ISeedDatabaseServices services)
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
        public Task InsertPersonsPF(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}