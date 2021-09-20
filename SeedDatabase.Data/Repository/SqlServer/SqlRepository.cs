using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeedDatabase.Data.Context;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        protected readonly SeedDatabaseContext _context;
        protected readonly ILogger<SqlRepository<T>> _logger;
        public SqlRepository(IServiceScopeFactory factory, ILogger<SqlRepository<T>> logger)
        {
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<SeedDatabaseContext>();

            _logger = logger;
        }
        public async Task Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task DeleteMany(IEnumerable<T> data)
        {
            try
            {
                _context.Set<T>().RemoveRange(data);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task<IEnumerable<T>> FindAll()
        {
            IEnumerable<T> entities = null;

            try
            {
                entities = await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return entities;
        }
        public async Task<T> FindOne(Expression<Func<T, bool>> filterExpression)
        {
            object entity = null;

            try
            {
                entity = await _context.Set<T>().FirstOrDefaultAsync(filterExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return (T)entity;
        }
        public async Task InsertOne(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task InsertMany(IEnumerable<T> data)
        {
            try
            {
                _context.Set<T>().AddRange(data);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task UpdateMany(IEnumerable<T> data)
        {
            try
            {
                _context.Set<T>().UpdateRange(data);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task<IEnumerable<Documento>> GetDocumentsWithPersons()
        {
            IEnumerable<Documento> documentos = null;

            try
            {
                documentos = await _context.Set<Documento>()
                    .Include(p => p.Pessoa)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return documentos;
        }
    }
}
