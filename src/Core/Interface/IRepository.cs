using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTrack { get; }
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        List<T> Get();
        List<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        T GetOne(Expression<Func<T, bool>> filter);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        void Add(T entity);
        Task AddAsync(T entity);
        void DeleteOne(T entity);
        Task DeleteOneAsync(T entity);
        void DeleteMany(Expression<Func<T, bool>> filter);
        Task DeleteManyAsync(Expression<Func<T, bool>> filter);
        int Count(Expression<Func<T, bool>> filter);
        bool IsExistAny(Expression<Func<T, bool>> filter);
        Task<bool> IsExistAnyAsync(Expression<Func<T, bool>> filter);
    }
}
