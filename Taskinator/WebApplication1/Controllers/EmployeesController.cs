using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.Models;

namespace Taskinator.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly TaskinatorMVCContext _context;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(TaskinatorMVCContext context)
        {
            _context = context;
            _employeeRepository = new EmployeeRepository(_context);
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return _context.Employees != null ?
                        View(await _context.Employees.ToListAsync()) :
                        Problem("Entity set 'TaskinatorContext.Employee'  is null.");
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving employee details: {ex.Message}");
            }
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LastName,FirstName,Role,Department_ID,Job_ID,Username,Password")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.CreateEmployee(employee);
                    return RedirectToAction(nameof(Index));
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while creating the employee: {ex.Message}");
            }
        }

        // GET: Employees/Edit/5
        public IActionResult GetEmployeeEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the employee to edit: {ex.Message}");
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,LastName,FirstName,Role,Department_ID,Job_ID,Username,Password")] Employee employee)
        {
            try
            {
                if (id != employee.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _employeeRepository.EditEmployee(employee,id);
                    return RedirectToAction(nameof(Index));
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while editing the employee: {ex.Message}");
            }
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the employee to delete: {ex.Message}");
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployeeConfirmed(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while deleting the employee: {ex.Message}");
            }
        }
    }
}

