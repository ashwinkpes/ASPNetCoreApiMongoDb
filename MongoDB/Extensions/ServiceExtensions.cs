using Microsoft.Extensions.DependencyInjection;

using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Manager;
using MongoDB.Repository;

namespace MongoDB.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<IPostRepository<Post>, PostRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IAccountManager<User>, AccountManager>(); 

            return services;
        }
    }
}
