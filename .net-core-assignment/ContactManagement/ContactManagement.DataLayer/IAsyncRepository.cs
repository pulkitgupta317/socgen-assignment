using ContactManagement.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.DataLayer
{
    public interface IAsyncRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id, string includeProperties);

        Task<List<T>> ListAsync(string includeProperties);
        
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
        
        Task<int> AddAsync(T entity);
        
        void Delete(T entity);
        
        void Update(T entity);

        Task SaveAsync();
    }
}
