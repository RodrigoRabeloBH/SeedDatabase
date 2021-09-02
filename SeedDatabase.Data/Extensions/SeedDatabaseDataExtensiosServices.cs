using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedDatabase.Data.Context;
using SeedDatabase.Data.Repository;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Data.Extensions
{
    public static class SeedDatabaseDataExtensiosServices
    {
        public static IServiceCollection AddSeedDatabaseDataExtensionsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            services.AddTransient<IPessoaPFRepository, PessoaPFRepository>();

            services.AddTransient<IDocumentoRepository, DocumentoRepository>();

            services.AddDbContext<SeedDatabaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
