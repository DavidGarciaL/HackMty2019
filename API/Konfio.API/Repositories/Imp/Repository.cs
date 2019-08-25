using Konfio.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Konfio.API.Repositories.Imp
{
    public class Repository<T>: IRepository<T> where T: class, IEntity
    {
        protected readonly KonfioContext _db;
        protected readonly DbSet<T> dbSet;

        public Repository(KonfioContext db)
        {
            this._db = db;
            dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public T Find(Guid id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<T> GetAllIncluding(Expression<Func<T, object>> predicate)
        {
            return dbSet.Include(predicate);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
