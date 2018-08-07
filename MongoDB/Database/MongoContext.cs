using Microsoft.Extensions.Configuration;

using MongoDB.Database.Models;
using MongoDB.Driver;

namespace MongoDB.Database
{
    public class MongoContext : IMongoContext
    {
        private readonly IConfiguration _config;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration config)
        {
            _config = config;
            _client = new MongoClient(config["MongoDB:Connection"]);
            _database = _client.GetDatabase(config["MongoDB:Database"]);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }
    }
}
