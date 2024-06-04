using EFDataAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

// https://dev.to/karenpayneoregon/gentle-introduction-to-generic-repository-pattern-with-c-1jn0
namespace EFDataAccessLib.DAL
{
    public class GenericRepository<TEntity, TKey>  : IGenericRepository<TEntity, TKey> where TEntity : DbEntityObject
    {
        internal PeopleContext _peopleContext;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
            _dbSet = _peopleContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetByIdWithNoTrackingAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllByIdAsync(IEnumerable<int> ids, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByIdWithNoTrackingAsync(IEnumerable<int> ids, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithNoTrackingAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void InsertAsync(TEntity entity)
        {
            _dbSet.AddAsync(entity);
        }

        public virtual void InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
        }
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }
        public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            _dbSet.RemoveRange(entitiesToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entitiesToUpdate)
        {
            _dbSet.UpdateRange(entitiesToUpdate);
        }
    }
}
