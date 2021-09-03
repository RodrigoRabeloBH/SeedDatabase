using Microsoft.Extensions.Logging;
using Nest;
using SeedDatabase.Data.Settings;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository.ElasticSearch
{
    public class SeedPessoaPFElasticRepository : ISeedPessoaPFElasticRepository
    {
        private readonly ILogger<SeedPessoaPFElasticRepository> _logger;
        private readonly IElasticClient _elasticClient;

        public SeedPessoaPFElasticRepository(ILogger<SeedPessoaPFElasticRepository> logger)
        {
            _logger = logger;
            _elasticClient = new ElasticClient(ElastichSearchSettings.BuildElasticSettings("pessoa_pf"));
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
