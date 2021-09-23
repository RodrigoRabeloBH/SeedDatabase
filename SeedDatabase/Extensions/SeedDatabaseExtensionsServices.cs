using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Helpers;
using SeedDatabase.Services;

namespace SeedDatabase.Extensions
{
    public static class SeedDatabaseExtensionsServices
    {
        public static IServiceCollection AddSeedDatabaseExtensionsServices(this IServiceCollection services)
        {
            services.AddTransient<ISeedDatabaseServices, SeedDatabaseServices>();

            services.AddTransient<IApplicationServices, ApplicationServices>();

            services.AddTransient<IDapperPessoaServices, DapperPessoaServices>();

            services.AddAutoMapper(typeof(MappingProfiles));

            return services;
        }
    }
}