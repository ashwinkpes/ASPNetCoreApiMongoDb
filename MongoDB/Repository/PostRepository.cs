using Microsoft.EntityFrameworkCore;

using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class PostRepository : IPostRepository<Post>
    {
        private readonly IMongoContext _context;

        public PostRepository(IMongoContext context)
        {
            _context = context;
        }

        public Task AddAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> FindAsync(Guid id)
        {
            return await _context.Users
                .AsQueryable()
                .Select(x => x.Posts.FirstOrDefault(p => p.Id == id))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                List<Post> posts = new List<Post>();

                foreach (User user in _context.Users.AsQueryable().ToList())
                {
                    posts.AddRange(user.Posts);
                }

                return posts;
            });
        }

        public Task UpdateAsync(Guid id, Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
