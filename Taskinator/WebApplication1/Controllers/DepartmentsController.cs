using Microsoft.AspNetCore.Mvc;

namespace Taskinator.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
