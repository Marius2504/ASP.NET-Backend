using Microsoft.EntityFrameworkCore;
using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public virtual void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToArray();
        }
        

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async void Update(TEntity entity)
        {
            //_context.Set<TEntity>().Update(entity);
            _context.Entry(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
