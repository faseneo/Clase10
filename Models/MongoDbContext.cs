using MongoDB.Driver;

namespace Clase10.Models{
    public class MongoDbContext{
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config){
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("Clase10");            
            }
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        }
    }
