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
    public class SeedDocumentoElasticRepository : ISeedDocumentoElasticRepository
    {
        private readonly ILogger<SeedDocumentoElasticRepository> _logger;
        private readonly IElasticClient _elasticClient;
        public SeedDocumentoElasticRepository(ILogger<SeedDocumentoElasticRepository> logger)
        {
            _logger = logger;
            _elasticClient = new ElasticClient(ElastichSearchSettings.BuildElasticSettings("documento"));
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

