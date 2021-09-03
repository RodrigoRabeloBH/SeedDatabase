using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository
{
    public class PessoaPFRepository : SeedDatabaseRepository<Pessoa_PF>, IPessoaPFRepository
    {
        public PessoaPFRepository(IServiceScopeFactory factory, ILogger<SeedDatabaseRepository<Pessoa_PF>> logger) : base(factory, logger)
        {
        }
    }
}