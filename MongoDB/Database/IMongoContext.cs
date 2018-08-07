using MongoDB.Database.Models;
using MongoDB.Driver;

namespace MongoDB.Database
{
    public interface IMongoContext
    {
        IMongoCollection<User> Users { get; }
    }
}
