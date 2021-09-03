namespace SeedDatabase.Settings
{
    public class MongoSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string ConnectionString
        {
            get
            {
                return $"mongodb//{Host}:{Port}";
            }
        }
    }
}