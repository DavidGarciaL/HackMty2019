using Konfio.API.Models;
using Konfio.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Konfio.API.Services.Imp
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        //protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repository;

        public Service(
            //IUnitOfWork unitOfWork, 
            IRepository<T> repository)
        {
            //this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public virtual async Task<T> ActivateAsync(Guid id)
        {
            //if (!await _repository.AnyAsync(e => e.Id == id))
            //    throw new CustomException("objectNotExists", "The object does not exist");

            var entity = await GetAsync(id);
            //entity.Active = true;
            _repository.Update(entity);
            //await _unitOfWork.SaveAsync();
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _repository.Add(entity);
            //await _unitOfWork.SaveAsync();
            return entity;
        }

        public virtual async Task DeactivateAsync(Guid id)
        {
            //if (!await _repository.AnyAsync(e => e.Id == id))
            //    throw new CustomException("objectNotExists", "The object does not exist");

            var entity = await GetAsync(id);
            //entity.Active = false;
            _repository.Update(entity);
            //await _unitOfWork.SaveAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            T entity = await _repository.GetAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                //await _unitOfWork.SaveAsync();
            }
            else
            {
                //throw new CustomException("objectNotExists", "The object does not exist");
            }

            return;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<T> FindAsync(Guid id)
        {
            return await _repository.FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(Guid id, T entity)
        {
            //if (!await _repository.AnyAsync(e => e.Id == id))
            //    throw new CustomException("objectNotExists", "The object does not exist");

            _repository.Update(entity);
            //await _unitOfWork.SaveAsync();
            return entity;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //_unitOfWork.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
