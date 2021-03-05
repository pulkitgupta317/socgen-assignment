using ContactManagement.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.DataLayer
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T: BaseEntity
    {
        protected readonly ContactManagementContext _context;
        protected readonly DbSet<T> _entity;

        public AsyncRepository(ContactManagementContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        private IQueryable<T> GetQueryable(Expression<Func<T, bool>>
            filter = null, string includeProperties = null)
        {
            includeProperties = includeProperties == null ? string.Empty : includeProperties;
            IQueryable<T> query = _entity;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public async Task<int> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return entity.Id;
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public Task<T> GetByIdAsync(int id, string includeProperties)
        {
            return GetQueryable(x => x.Id == id, includeProperties: includeProperties).FirstOrDefaultAsync();
        }

        public Task<List<T>> ListAsync(string includeProperties)
        {
            return GetQueryable(null, includeProperties: includeProperties).ToListAsync();
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate).ToListAsync();
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
