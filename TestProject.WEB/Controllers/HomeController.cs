using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TestProject.WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
