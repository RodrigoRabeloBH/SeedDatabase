using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository
{
    public class PessoaRepository : SeedDatabaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(IServiceScopeFactory factory, ILogger<SeedDatabaseRepository<Pessoa>> logger) : base(factory, logger)
        {
        }
    }
}
