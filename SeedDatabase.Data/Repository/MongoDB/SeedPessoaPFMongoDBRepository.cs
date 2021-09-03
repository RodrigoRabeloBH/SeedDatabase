using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository.MongoDB
{
    public class SeedPessoaPFMongoDBRepository : ISeedPessoaPFMongoDBRepository
    {
        private readonly string databaseName = "ClienteUnico";
        private readonly string collectionName = "Pessoa_fisica";
        private readonly IMongoCollection<Pessoa_PF> _pessoaPFCollection;
        private readonly ILogger<SeedPessoaPFMongoDBRepository> _logger;
        public SeedPessoaPFMongoDBRepository(
            IMongoClient mongoClient, 
            ILogger<SeedPessoaPFMongoDBRepository> logger)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _pessoaPFCollection = database.GetCollection<Pessoa_PF>(collectionName);
            _logger = logger;
        }
        public async Task SeedData(IEnumerable<Pessoa_PF> pessoas)
        {
            try
            {
                await _pessoaPFCollection.InsertManyAsync(pessoas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
