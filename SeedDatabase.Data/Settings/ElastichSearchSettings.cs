using System;
using Nest;

namespace SeedDatabase.Data.Settings
{
    public class ElastichSearchSettings
    {
        public string Uri { get; set; }
        public string DefaultIndex { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static ConnectionSettings BuildElasticSettings(string index)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"));

            settings.DefaultIndex(index);

            settings.BasicAuthentication("elastic", "changeme");

            return settings;
        }
    }
}