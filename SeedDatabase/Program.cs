using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SeedDatabase.Data.Context;
using SeedDatabase.Data.Extensions;
using SeedDatabase.Data.Repository;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Services;

namespace SeedDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureServices((hostContext, services) =>
                       {
                           IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

                           ConfigureConfiguration(configurationBuilder);

                           IConfiguration configuration = configurationBuilder.Build();

                           services.AddTransient<ISeedDatabaseServices, SeedDatabaseServices>();

                           services.AddSeedDatabaseDataExtensionsServices(configuration);

                           services.AddHostedService<Worker>();
                       });
        }

        public static void ConfigureConfiguration(IConfigurationBuilder config)
        {
            config.SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }
    }
}
