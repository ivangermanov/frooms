using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD methods

        //C
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        //R
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);

        IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);

        T GetById(object id);
        Task<T> GetByIdAsync(object id);

        T GetById(Expression<Func<T, bool>> idExpression, params Expression<Func<T, object>>[] includeExpressions);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> idExpression, params Expression<Func<T, object>>[] includeExpressions);

        T GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);

        //U
        int Update(T entityToUpdate);
        Task<int> UpdateAsync(T entityToUpdate);

        int AddOrUpdate(T[] entities);
        Task<int> AddOrUpdateAsync(T[] entities);

        //D
        int Delete(object id);
        Task<int> DeleteAsync(object id);
        int Delete(Expression<Func<T, bool>> predicate);
        Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);
        int Delete(T entityToDelete);
        Task<int> DeleteAsync(T entityToDelete);
    }
}
