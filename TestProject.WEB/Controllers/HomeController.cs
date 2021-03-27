using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Services.Interfaces;
using TestProject.ViewModels.EmployeeTaskViews;

namespace TestProject.WEB.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeTaskService _employeeTaskService;

        public HomeController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _employeeTaskService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeTaskRequestView model)
        {
            await _employeeTaskService.Create(model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeTaskService.Delete(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Finish(int id)
        {
            await _employeeTaskService.Finish(id);
            return View();
        }
    }
}
