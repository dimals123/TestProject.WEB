using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestProject.DataAccess.Entities;
using TestProject.DataAccess.Repositories.Interfaces;

namespace TestProject.DataAccess.Repositories
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(DbContext context) : base(context)
        {
        }

        public async new Task<EmployeeTask> Create(EmployeeTask item)
        {
            var result = await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
