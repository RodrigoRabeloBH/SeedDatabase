using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SeedDatabase.Data.Model;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository.Mongo
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IDocument
    {
        private readonly IMongoCollection<T> _collection;
        private readonly ILogger<MongoRepository<T>> _logger;
        public MongoRepository(ILogger<MongoRepository<T>> logger, IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));

            _logger = logger;
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType
                    .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                    .FirstOrDefault())?.CollectionName;
        }
        public virtual async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            object document = null;

            try
            {
                document = await _collection.Find(filterExpression).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return (T)document;
        }
        public virtual async Task<T> FindByIdAsync(string id)
        {
            object document = null;

            try
            {
                var objectId = new ObjectId(id);

                var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);

                document = await _collection.Find(filter).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return (T)document;
        }
        public virtual async Task InsertOneAsync(T document)
        {
            try
            {
                await _collection.InsertOneAsync(document);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual async Task InsertManyAsync(IEnumerable<T> documents)
        {
            try
            {
                await _collection.InsertManyAsync(documents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual async Task ReplaceOneAsync(T document, ObjectId objectId)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);

                await _collection.FindOneAndReplaceAsync(filter, document);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual async Task UpdateManyAsync(ObjectId objectId)
        {
            try
            {
                var filter = Builders<T>.Filter.Where(doc => doc.Id != objectId);

                await _collection.UpdateManyAsync(filter, Builders<T>.Update.Set(x => x.Name, "John Fucking Doe"));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual async Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression)
        {
            try
            {
                await _collection.FindOneAndDeleteAsync(filterExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual async Task DeleteByIdAsync(string id)
        {
            try
            {
                var objectId = new ObjectId(id);

                var filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);

                await _collection.FindOneAndDeleteAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression)
        {
            try
            {
                await _collection.DeleteManyAsync(filterExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public virtual IQueryable<T> AsQueryable()
        {
            IMongoQueryable<T> collection = null;

            try
            {
                collection = _collection.AsQueryable();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return collection;
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            IAsyncCursor<T> documents = null;

            try
            {
                documents = await _collection.FindAsync(Builders<T>.Filter.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return documents.ToList();
        }
        public virtual async Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            IAsyncCursor<T> documents = null;

            try
            {
                var c = await _collection.FindAsync(filterExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return documents.ToList();
        }
        public IEnumerable<Documento> FilterJoin()
        {
            IEnumerable<Documento> documents = null;

            try
            {
                documents = _collection.Aggregate()
                     .Lookup("Pessoa", "id_pessoa", "_id", "asPessoa")           
                     .As<Documento>()
                     .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return documents.ToList();
        }
    }
}