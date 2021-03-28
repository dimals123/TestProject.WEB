using System;
using System.Linq;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Services.Interfaces;
using TestProject.DataAccess.Entities;
using TestProject.DataAccess.Repositories.Interfaces;
using TestProject.ViewModels.EmployeeTaskViews;

namespace TestProject.BusinessLogic.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }

        public async Task<CreateEmployeeTaskResponseView> Create(CreateEmployeeTaskRequestView model)
        {
            var employeeTask = new EmployeeTask() {
                Name = model.Name,
                Description = model.Description,
                Employee = model.Employee
            };

            var newEmployeeTask = await _employeeTaskRepository.Create(employeeTask);
            var result = new CreateEmployeeTaskResponseView()
            {
                Id = newEmployeeTask.Id,
                Name = newEmployeeTask.Name,
                Description = newEmployeeTask.Description,
                Employee = newEmployeeTask.Employee,
                Finished = newEmployeeTask.Finished
            };

            return result;
        }

        public async Task Delete(int id)
        {
            var employeeTask = await _employeeTaskRepository.GetById(id);
            if (employeeTask == null)
            {
                throw new Exception();
            }
            await _employeeTaskRepository.Delete(employeeTask);
        }

        public async Task Finish(int id)
        {
            var employeeTask = await _employeeTaskRepository.GetById(id);

            if(employeeTask == null)
            {
                throw new Exception();
            }

            employeeTask.Finished = !employeeTask.Finished;
            await _employeeTaskRepository.Update(employeeTask);
        }

        public async Task<GetAllEmployeeTaskResponseView> GetAll()
        {
            var employeeTasks = await _employeeTaskRepository.GetAll();
            var result = new GetAllEmployeeTaskResponseView
            {
                EmployeeTasks = employeeTasks.Select(x => new EmployeeTaskGetAllEmployeeTaskResponseView()
                {
                    Description = x.Description,
                    Employee = x.Employee,
                    Name = x.Name,
                    Id = x.Id,
                    Finished = x.Finished
                }).ToList()
            };

            return result;
        }
    }
}
