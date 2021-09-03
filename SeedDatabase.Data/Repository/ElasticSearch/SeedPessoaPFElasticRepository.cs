using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository.ElasticSearch
{
    public class SeedPessoaPFElasticRepository : ISeedPessoaPFElasticRepository
    {
        private readonly ILogger<SeedPessoaPFElasticRepository> _logger;
        private readonly IElasticClient _elasticClient;
        private readonly IConfiguration _configuration;

        public SeedPessoaPFElasticRepository(
            ILogger<SeedPessoaPFElasticRepository> logger,
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            var settings = new ConnectionSettings(new Uri(_configuration["ElastichSearchSettings:Uri"]));
            var defaultIndex = "pessoafisica";
            var basicAuthUser = _configuration["ElastichSearchSettings:Username"];
            var basicAuthPassword = _configuration["ElastichSearchSettings:Password"];
            settings.DefaultIndex(defaultIndex);
            settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

            _logger = logger;
            _elasticClient = new ElasticClient(settings);
        }
        public async Task SeedData(IEnumerable<Pessoa_PF> pessoas)
        {
            try
            {
                foreach (var pessoa in pessoas)
                {
                    var response = await _elasticClient.IndexDocumentAsync(pessoa);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
