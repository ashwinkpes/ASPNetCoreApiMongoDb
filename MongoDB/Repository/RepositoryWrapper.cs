using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IUserRepository<User> Users { get; }
        public IPostRepository<Post> Posts { get; }

        public RepositoryWrapper(IUserRepository<User> users, IPostRepository<Post> posts)
        {
            Users = users;
            Posts = posts;
        }
    }
}
