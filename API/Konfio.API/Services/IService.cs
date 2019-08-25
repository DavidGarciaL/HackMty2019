using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Services
{
    public interface IService<T> : IDisposable where T: class
    {
        Task<T> ActivateAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task DeactivateAsync(Guid id);
        Task DeleteAsync(Guid id);
        IQueryable<T> GetAll();
        Task<T> GetAsync(Guid id);
        Task<T> FindAsync(Guid id);
        Task<T> UpdateAsync(Guid id, T entity);
    }
}
