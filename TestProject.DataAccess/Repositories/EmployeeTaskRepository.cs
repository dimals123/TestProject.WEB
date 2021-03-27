using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Entities;
using TestProject.DataAccess.Repositories.Interfaces;

namespace TestProject.DataAccess.Repositories
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(DbContext context) : base(context)
        {
        }
    }
}
