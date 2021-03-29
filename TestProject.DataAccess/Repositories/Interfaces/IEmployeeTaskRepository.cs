using System.Threading.Tasks;
using TestProject.DataAccess.Entities;

namespace TestProject.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeTaskRepository : IBaseRepository<EmployeeTask>
    {
        new Task<EmployeeTask> Create(EmployeeTask task);
    }
}
