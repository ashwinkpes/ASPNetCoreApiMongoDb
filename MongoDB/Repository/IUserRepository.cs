using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IUserRepository<T> : IRepository<T> where T : class, IUser
    {
        Task AddPostAsync(Guid id, Post post);
    }
}
