using System.Threading.Tasks;
using TestProject.ViewModels.EmployeeTaskViews;

namespace TestProject.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeTaskService
    {
        Task<GetAllEmployeeTaskResponseView> GetAll();
        Task<CreateEmployeeTaskResponseView> Create(CreateEmployeeTaskRequestView model);
        Task Finish(int id);
        Task Delete(int id);

    }
}
