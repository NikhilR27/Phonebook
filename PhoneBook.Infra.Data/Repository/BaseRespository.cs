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
        protected DbContext DbContext { get; set; }

        public RepositoryBase(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string[] includes = null)
        {
            IQueryable<T> result = DbContext.Set<T>().AsNoTracking().AsQueryable();

            if (includes != null)
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> result = DbContext.Set<T>().Where(expression).AsNoTracking().AsQueryable();

            if (includes != null)
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }

            return await result.ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
