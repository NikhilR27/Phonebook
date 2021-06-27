using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;

namespace PhoneBook.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected DbContext Context { get; set; }

        public RepositoryBase(DbContext dbContext) => this.Context = dbContext;

        public async Task<IEnumerable<T>> GetAllAsync(string[] includes = null)
        {
            IQueryable<T> result = this.Context.Set<T>().AsNoTracking<T>().AsQueryable<T>();
            List<T> listAsync = await result.ToListAsync<T>();
            IEnumerable<T> objs = (IEnumerable<T>)listAsync;
            result = (IQueryable<T>)null;
            return objs;
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(
            Expression<Func<T, bool>> expression)
        {
            IQueryable<T> result = this.Context.Set<T>().Where<T>(expression).AsNoTracking<T>().AsQueryable<T>();
            List<T> listAsync = await result.ToListAsync<T>();
            IEnumerable<T> objs = (IEnumerable<T>)listAsync;
            result = (IQueryable<T>)null;
            return objs;
        }

        public async Task CreateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await this.Context.Set<T>().AddAsync(entity);
            int num = await this.Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.Context.Entry<T>(entity).State = EntityState.Modified;
            int num = await this.Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            int num = await this.Context.SaveChangesAsync();
        }
    }
}
