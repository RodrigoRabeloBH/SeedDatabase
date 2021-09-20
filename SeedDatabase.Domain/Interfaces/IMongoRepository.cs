using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Domain.Interfaces
{
    public interface IMongoRepository<T> where T : IDocument
    {
        IQueryable<T> AsQueryable();
        Task InsertOneAsync(T document);
        Task InsertManyAsync(IEnumerable<T> documents);
        Task UpdateManyAsync(ObjectId objectId);
        Task ReplaceOneAsync(T document, ObjectId objectId);
        Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);
        Task DeleteByIdAsync(string id);
        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
        Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression);
        Task<IEnumerable<T>> GetAll();
        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);
        Task<T> FindByIdAsync(string id);
        IEnumerable<Documento> FilterJoin();
    }
}