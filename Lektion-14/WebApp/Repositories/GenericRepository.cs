using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        protected GenericRepository(DataContext context)
        {
            _context = context;
        }


        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id) ?? null!;
        }

        public virtual async Task<List<TEntity>> ReadAsync()
        {
            return await _context.Set<TEntity>().ToListAsync() ?? null!;
        }
    }
}
