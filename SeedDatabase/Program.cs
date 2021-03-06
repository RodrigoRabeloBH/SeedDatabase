using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SeedDatabase.Data.Extensions;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using SeedDatabase.Extensions;

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

                           services.AddSeedDatabaseExtensionsServices();

                           services.AddSeedDatabaseDataExtensionsServices(configuration);

                           services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

                           services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                               serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

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
