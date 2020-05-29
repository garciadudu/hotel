using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Servicos.Service
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity: class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _repository.AddAsync(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _repository.GetAllByFilterAsync(expression);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return await _repository.GetByFilterAsync(expression);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
