using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;
using MongoDB.Manager;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly IAccountManager<User> _accountManager;
        private readonly IMongoContext _context;

        public UserRepository(IAccountManager<User> accountManager, IMongoContext context)
        {
            _accountManager = accountManager;
            _context = context;
        }

        public async Task<Token> SignInAsync(User model)
        {
            return await _accountManager.SignInAsync(model);
        }

        public async Task<Token> SignUpAsync(User model)
        {
            return await _accountManager.SignUpAsync(model);
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
            throw new NotImplementedException();
        }

        public async Task AddPostAsync(Guid id, Post post)
        {
            User user = await FindAsync(id);
            user.Posts.Add(post);

            if (user is null)
                throw new KeyNotFoundException("User not found");

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
