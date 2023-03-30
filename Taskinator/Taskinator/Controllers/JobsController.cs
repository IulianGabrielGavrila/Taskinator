using Microsoft.AspNetCore.Mvc;

namespace Taskinator.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
