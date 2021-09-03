using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SeedDatabase.Data.Context;
using SeedDatabase.Data.Repository;
using SeedDatabase.Data.Repository.MongoDB;
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

            services.AddTransient<ISeedPessoaMongoDBRepository, SeedPessoaMongoDBRepository>();

            services.AddDbContext<SeedDatabaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MongoConnection")));

            return services;
        }
    }
}
