using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeedDatabase.Data.Context;
using SeedDatabase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Data.Repository
{
    public class SeedDatabaseRepository<T> : ISeedDatabaseRepository<T> where T : class
    {
        protected readonly SeedDatabaseContext _context;
        protected readonly ILogger<SeedDatabaseRepository<T>> _logger;
        public SeedDatabaseRepository(IServiceScopeFactory factory, ILogger<SeedDatabaseRepository<T>> logger)
        {
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<SeedDatabaseContext>();
            _logger = logger;
        }

        public async Task SeedData(IEnumerable<T> data)
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
    }
}
