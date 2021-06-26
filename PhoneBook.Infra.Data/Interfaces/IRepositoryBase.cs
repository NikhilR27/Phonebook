using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Data.Repository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string[] includes = null);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
