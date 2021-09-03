using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository.MongoDB
{
    public class SeedPessoaMongoDBRepository : ISeedPessoaMongoDBRepository
    {
        private readonly string databaseName = "ClienteUnico";
        private readonly string collectionName = "Pessoa";
        private readonly IMongoCollection<Pessoa> _pessoaCollection;
        private readonly ILogger<SeedPessoaMongoDBRepository> _logger;
        public SeedPessoaMongoDBRepository(IMongoClient mongoClient, ILogger<SeedPessoaMongoDBRepository> logger)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _pessoaCollection = database.GetCollection<Pessoa>(collectionName);
            _logger = logger;
        }
        public async Task SeedData(IEnumerable<Pessoa> pessoas)
        {
            try
            {
                await _pessoaCollection.InsertManyAsync(pessoas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}