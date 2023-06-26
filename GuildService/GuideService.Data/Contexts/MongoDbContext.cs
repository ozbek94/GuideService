using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GuideService.Data.Contexts
{
    public class MongoDbContext 
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<DatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;
    }
}
