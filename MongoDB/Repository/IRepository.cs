using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(Guid id);
    }
}
