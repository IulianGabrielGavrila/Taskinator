using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using TaskinatorDAL.Models;
using ErrorViewModel = WebApplication1.Models.ErrorViewModel;
using TaskinatorDAL.DBContext;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee employee)
        {
            
            {
                var optionsBuilder = new DbContextOptionsBuilder<TaskinatorMVCContext>()
                                      .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Data Source=DESKTOP-GO75Q5S;Initial Catalog=Taskinator;Encrypt=False;Integrated Security=true");
                using (TaskinatorMVCContext db = new TaskinatorMVCContext(optionsBuilder.Options))
                {
                    var obj = db.Employees.FirstOrDefault(a => a.Username == employee.Username && a.Password == employee.Password);
                    if (obj != null)
                    {
                        HttpContext.Session.SetString("UserID", obj.ID.ToString());
                        HttpContext.Session.SetString("UserName", obj.Username.ToString());
                        return Redirect("https://localhost:8080/employees");
                        // return View(employee);
                    }
                }
            }
            return View(employee);
        }
        

        public ActionResult UserDashBoard()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}