using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestProject.BusinessLogic.Services.Interfaces;
using TestProject.ViewModels.EmployeeTaskViews;

namespace TestProject.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class HomeController : Controller
    {

        private readonly IEmployeeTaskService _employeeTaskService;

        public HomeController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var respone = await _employeeTaskService.GetAll();
            return Ok(respone);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateEmployeeTaskRequestView model)
        {
            var respone = await _employeeTaskService.Create(model);
            return Ok(respone);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeTaskService.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("finish/{id}")]
        public async Task<IActionResult> Finish(int id)
        {
            await _employeeTaskService.Finish(id);
            return Ok();
        }
    }
}
