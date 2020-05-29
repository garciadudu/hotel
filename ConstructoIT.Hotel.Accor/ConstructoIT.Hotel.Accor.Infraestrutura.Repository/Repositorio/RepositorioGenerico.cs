using ConstructoIT.Hotel.Accor.Domain.Core.Interface.Repository;
using ConstructoIT.Hotel.Accor.Dominio.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Repositorio
{
    public abstract class RepositorioGenerico<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ConstructoItDbContext _context;

        public RepositorioGenerico(ConstructoItDbContext context)
        {
            _context = context;
        }
        public virtual void Add(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public virtual void Update(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Remove(TEntity obj)
        {
            try
            { 
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

    }
}
