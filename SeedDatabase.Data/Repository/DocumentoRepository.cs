using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository
{
    public class DocumentoRepository : SeedDatabaseRepository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(IServiceScopeFactory factory, ILogger<SeedDatabaseRepository<Documento>> logger) : base(factory, logger)
        {
        }
    }
}