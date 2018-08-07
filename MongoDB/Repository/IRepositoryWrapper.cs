using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository<User> Users { get; }
        IPostRepository<Post> Posts { get; }
    }
}
