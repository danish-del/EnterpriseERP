using EnterpriseERP.Application.Common.Pagination;
using EnterpriseERP.Application.Interface;
using EnterpriseERP.Insfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseERP.Insfrastructure.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext Context)
        {
            _context = Context;
            _dbSet = Context.Set<T>();
        }
        public async Task<PagedResult<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet.AsQueryable();
            var totalcount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalcount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
          var entity =  await _dbSet.FindAsync(id);
            if (entity == null)
                return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
