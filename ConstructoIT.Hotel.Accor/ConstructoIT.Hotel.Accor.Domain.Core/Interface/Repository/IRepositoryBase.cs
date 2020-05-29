using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity: class
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(int id);
    }
}
