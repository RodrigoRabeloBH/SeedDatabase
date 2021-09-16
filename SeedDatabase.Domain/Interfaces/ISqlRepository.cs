using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISqlRepository<T> where T : class
    {
        Task InsertMany(IEnumerable<T> entity);
        Task InsertOne(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> FindOne(Expression<Func<T, bool>> filterExpression);
        Task<IEnumerable<T>> FindAll();
    }
}
