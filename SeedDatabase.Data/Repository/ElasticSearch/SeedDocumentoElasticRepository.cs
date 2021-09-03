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
    public class SeedDocumentoElasticRepository : ISeedDocumentoElasticRepository
    {
        private readonly ILogger<SeedDocumentoElasticRepository> _logger;
        private readonly IElasticClient _elasticClient;
        private readonly IConfiguration _configuration;

        public SeedDocumentoElasticRepository(ILogger<SeedDocumentoElasticRepository> logger, IElasticClient elasticClient, IConfiguration configuration)
        {
            _configuration = configuration;
            var settings = new ConnectionSettings(new Uri(_configuration["ElastichSearchSettings:Uri"]));
            var defaultIndex = "documento";
            var basicAuthUser = _configuration["ElastichSearchSettings:Username"];
            var basicAuthPassword = _configuration["ElastichSearchSettings:Password"];
            settings.DefaultIndex(defaultIndex);
            settings.BasicAuthentication(basicAuthUser, basicAuthPassword);

            _logger = logger;
            _elasticClient = new ElasticClient(settings);
        }
        public async Task SeedData(IEnumerable<Documento> documentos)
        {
            try
            {
                foreach (var documento in documentos)
                {
                    var response = await _elasticClient.IndexDocumentAsync(documento);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

    }
}

