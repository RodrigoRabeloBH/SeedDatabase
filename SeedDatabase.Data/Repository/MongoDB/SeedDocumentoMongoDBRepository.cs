using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository.MongoDB
{
    public class SeedDocumentoMongoDBRepository : ISeedDocumentoMongoDBRepository
    {
        private readonly string databaseName = "ClienteUnico";
        private readonly string collectionName = "Documento";
        private readonly IMongoCollection<Documento> _documentoCollection;
        private readonly ILogger<SeedDocumentoMongoDBRepository> _logger;
        public SeedDocumentoMongoDBRepository(IMongoClient mongoClient, ILogger<SeedDocumentoMongoDBRepository> logger)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _documentoCollection = database.GetCollection<Documento>(collectionName);
            _logger = logger;
        }
        public async Task SeedData(IEnumerable<Documento> documentos)
        {
            try
            {
                await _documentoCollection.InsertManyAsync(documentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}

