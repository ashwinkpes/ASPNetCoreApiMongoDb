using MongoDB.Database.Models;

namespace MongoDB.Repository
{
    public interface IPostRepository<T> : IRepository<T> where T : class, IPost
    {

    }
}
