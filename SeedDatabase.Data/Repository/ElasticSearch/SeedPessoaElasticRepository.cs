using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nest;
using SeedDatabase.Data.Settings;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository.ElasticSearch
{
    public class SeedPessoaElasticRepository : ISeedPessoaElasticRepository
    {
        private readonly ILogger<SeedPessoaElasticRepository> _logger;
        private readonly IElasticClient _elasticClient;
        public SeedPessoaElasticRepository(ILogger<SeedPessoaElasticRepository> logger)
        {
            _logger = logger;
            _elasticClient = new ElasticClient(ElastichSearchSettings.BuildElasticSettings("pessoa"));
        }
        public async Task SeedData(IEnumerable<Pessoa> pessoas)
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