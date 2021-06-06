
using Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext dbContext;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public IQueryable<T> Table => entities.AsQueryable<T>();
        public IQueryable<T> TableNoTrack => entities.AsNoTracking<T>();

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await entities.FindAsync(id);
        }

        public List<T> Get()
        {
            return entities.ToList();
        }
        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).ToList();
        }
        public async Task<List<T>> GetAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }


        public T GetOne(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefault(predicate);
        }
        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new Exception("Can not add");
            this.entities.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new Exception("Can not add");
            await this.entities.AddAsync(entity);
        }

        public void DeleteOne(T entity)
        {
            this.entities.Remove(entity);
        }
        public void DeleteMany(Expression<Func<T, bool>> filter)
        {
            this.entities.RemoveRange(this.entities.Where(filter));
        }

        public void Update(T entity)
        {
            this.entities.Update(entity);
        }

        public Task DeleteOneAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return this.entities.Where(filter).Count();
        }

        public bool IsExistAny(Expression<Func<T, bool>> filter)
        {
            return this.entities.Where(filter).Any();
        }
        public async Task<bool> IsExistAnyAsync(Expression<Func<T, bool>> filter)
        {
            return await this.entities.Where(filter).AnyAsync();
        }
    }
}
