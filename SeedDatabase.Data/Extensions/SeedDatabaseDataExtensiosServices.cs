using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeedDatabase.Data.Context;
using SeedDatabase.Data.Repository;
using SeedDatabase.Data.Repository.Mongo;
using SeedDatabase.Data.Repository.SqlServer;
using SeedDatabase.Domain.Interfaces;

namespace SeedDatabase.Data.Extensions
{
    public static class SeedDatabaseDataExtensiosServices
    {
        public static IServiceCollection AddSeedDatabaseDataExtensionsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SeedDatabaseContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.AddTransient(typeof(ISqlRepository<>), typeof(SqlRepository<>));

            services.AddTransient<IDapperPessoaRepository, DapperPessoaRepository>();

            return services;
        }
    }
}
