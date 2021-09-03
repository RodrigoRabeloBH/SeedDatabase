using Microsoft.Extensions.DependencyInjection;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Services;

namespace SeedDatabase.Extensions
{
    public static class SeedDatabaseExtensionsServices
    {
        public static IServiceCollection AddSeedDatabaseExtensionsServices(this IServiceCollection services)
        {
            services.AddTransient<ISeedDatabaseSQLServerServices, SeedDatabaseSQLServerServices>();

            services.AddTransient<ISeedDatabaseMongoDBServices, SeedDatabaseMongoDBServices>();

            services.AddTransient<ISeedDatabaseElasticSearchServices, SeedDatabaseElasticSearchServices>();

            services.AddTransient<ISeedDatabaseServices, SeedDatabaseServices>();

            return services;
        }
    }
}