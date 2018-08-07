using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Driver;

using System;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Manager
{
    public class AccountManager : IAccountManager<User>
    {
        private readonly IMongoContext _context;

        public AccountManager(IMongoContext context)
        {
            _context = context;
        }

        public async Task<Token> SignInAsync(User model)
        {
            // Just for demostration purposes
            User user = await _context
                .Users
                .Find(x => x.Email == model.Email && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user is null)
                return null;

            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }

        public async Task<Token> SignUpAsync(User model)
        {
            User user = await _context
                .Users
                .Find(x => x.Email == model.Email)
                .FirstOrDefaultAsync();

            if (user != null)
                throw new InvalidOperationException("User already exists");

            await _context.Users.InsertOneAsync(model);
            byte[] secureHash = Encoding.UTF8.GetBytes("SuperSecureHash");
            return new Token(secureHash, DateTime.Now.AddMinutes(10));
        }
    }
}
