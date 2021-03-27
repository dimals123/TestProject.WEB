using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Entities;

namespace TestProject.DataAccess
{
    public class TestProjectContext : DbContext
    {
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        public TestProjectContext(DbContextOptions<TestProjectContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
