using Froom.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Froom.Data.Repositories
{
    public class FroomRepository<T> : GenericRepository<T, FroomDbContext>
        where T : class
    {
        public FroomRepository(FroomDbContext context) : base(context)
        {
        }
    }

    public class GenericRepository<T, TContext> : IGenericRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected TContext _dbContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(TContext context)
        {
            this._dbContext = context;
            this._dbSet = context.Set<T>();
        }

        #region C

        public virtual T Add(T entity)
        {
            var newEntity = _dbSet.Add(entity);
            _dbContext.SaveChanges();

            return newEntity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var newEntity = _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();

            return newEntity;
        }


        public virtual IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var newEntities = _dbSet.AddRange(entities);
            _dbContext.SaveChanges();

            return newEntities;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            var newEntities = _dbSet.AddRange(entities);
            await _dbContext.SaveChangesAsync();

            return newEntities;
        }

        #endregion

        #region R

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var query = Aggregate(includeExpressions);
                return query.AsQueryable();
            }

            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var query = Aggregate(includeExpressions);
                return query.Where<T>(predicate).AsQueryable<T>();
            }
            return _dbSet.Where(predicate);
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }


        public virtual T GetById(Expression<Func<T, bool>> idExpression, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(idExpression);
            }

            return _dbSet.SingleOrDefault(idExpression);
        }

        public virtual async Task<T> GetByIdAsync(Expression<Func<T, bool>> idExpression, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return await set.SingleOrDefaultAsync(idExpression);
            }

            return await _dbSet.SingleOrDefaultAsync(idExpression);
        }



        public virtual T GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return set.FirstOrDefault(predicate);
            }

            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual async Task<T> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                         (_dbSet, (current, expression) => current.Include(expression));

                return await set.FirstOrDefaultAsync(predicate);
            }

            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        #endregion

        #region U

        public virtual int Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int AddOrUpdate(T[] entities)
        {
            _dbSet.AddOrUpdate(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> AddOrUpdateAsync(T[] entities)
        {
            _dbSet.AddOrUpdate(entities);
            return await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region D

        public virtual int Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual async Task<int> DeleteAsync(object id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            return await DeleteAsync(entityToDelete);
        }

        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = GetAllBy(predicate);
            foreach (var obj in objects)
                _dbSet.Remove(obj);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var objects = GetAllBy(predicate);
            foreach (var obj in objects)
                _dbSet.Remove(obj);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int Delete(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return await _dbContext.SaveChangesAsync();
        }

        #endregion

        private IQueryable<T> Aggregate(Expression<Func<T, object>>[] includeExpressions) => includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                         (_dbSet, (current, expression) => current.Include(expression));
    }
    }
