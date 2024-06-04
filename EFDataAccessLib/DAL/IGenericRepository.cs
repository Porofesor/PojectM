using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DAL
{
    public interface IGenericRepository<T, TKey>
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllWithNoTrackingAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithNoTrackingAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllByIdAsync(IEnumerable<int> ids, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllByIdWithNoTrackingAsync(IEnumerable<int> ids, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void InsertAsync(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertRangeAsync(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(T entityToDelete);
        void DeleteRange(IEnumerable<T> entitiesToDelete);
        void Update(T entityToUpdate);
        void UpdateRange(IEnumerable<T> entities);
    }

}
