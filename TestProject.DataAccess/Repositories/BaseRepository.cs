using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.DataAccess.Repositories.Interfaces;

namespace TestProject.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task Create(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Update(T item)
        {
            _dbSet.Update(item);
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
