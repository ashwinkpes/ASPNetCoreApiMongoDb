using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly IMongoContext _context;

        public UserRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User> FindAsync(Guid id)
        {
            return await _context.Users.Find(x => x.Id == id).FirstAsync();
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, User entity)
        {
            User user = await FindAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");

            FilterDefinition<User> filter = Builders<User>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<User> update = Builders<User>.Update.Set(x => x, user);

            await _context.Users.UpdateOneAsync(filter, update);
        }

        public async Task AddPostAsync(Guid id, Post post)
        {
            User user = await FindAsync(id);

            if (user is null)
                throw new KeyNotFoundException("User not found");

            user.Posts.Add(post);

            FilterDefinition<User> filter = Builders<User>.Filter.Eq(u => u.Id, id);
            UpdateDefinition<User> update = Builders<User>.Update.Set(x => x.Posts, user.Posts);

            await _context.Users.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.Users.DeleteOneAsync(x => x.Id == id);
        }
    }
}
