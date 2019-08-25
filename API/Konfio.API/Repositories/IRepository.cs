using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Konfio.API.Repositories
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        Task AddAsync(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        T Find(Guid id);
        Task<T> FindAsync(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(Expression<Func<T, object>> predicate);
        Task<T> GetAsync(Guid id);
        void Update(T entity);
    }
}
