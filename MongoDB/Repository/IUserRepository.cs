using MongoDB.Database.Models;

using System;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {
        Task<Token> SignInAsync(T model);
        Task<Token> SignUpAsync(T model);
        Task AddPostAsync(Guid id, Post post);
    }
}
