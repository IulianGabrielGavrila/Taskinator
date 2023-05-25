using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.ICRUD;
using TaskinatorDAL.Models;

namespace Taskinator.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskinatorMVCContext _context;
        private readonly TaskRepository _taskRepository;

        public TasksController(TaskinatorMVCContext context)
        {
            _context = context;
            _taskRepository = new TaskRepository(_context);
        }
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskRepository.Index();

            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var task = _taskRepository.GetTaskById(id);

                if (task == null)
                {
                    return NotFound();
                }

                return View(task);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving task details: {ex.Message}");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Difficulty,Status,BoardName")] Task_Table task)
        {
            try
            {
                //if (ModelState.IsValid)

                task.Creation_Date= DateTime.Now;

                var boards = _context.Boards.ToList(); // Retrieve all boards from the database

                foreach (var board in boards)
                {
                    if (board.Name == task.BoardName)
                    {                  
                        task.Board_ID = board.ID;
                        break; 
                    }
                }

                _taskRepository.CreateTask(task);
                return RedirectToAction(nameof(Index));


                //return View(task);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while creating the task: {ex.Message}");
            }
        }
        public IActionResult GetTaskEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var task = _taskRepository.GetTaskById(id);

                if (task == null)
                {
                    return NotFound();
                }

                return View("/Views/Tasks/Edit.cshtml");
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the task to edit: {ex.Message}");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Difficulty,Status,BoardName")] Task_Table task)
        {
            try
            {
                if (id != task.ID)
                {
                    return NotFound();
                }
                var boards = _context.Boards.ToList(); // Retrieve all boards from the database

                foreach (var board in boards)
                {
                    if (board.Name == task.BoardName)
                    {
                        task.Board_ID = board.ID;
                        break;
                    }
                }

                //if (ModelState.IsValid)
                {
                    
                    _taskRepository.EditTask(task, id);
                    return RedirectToAction(nameof(Index));
                }

                //return View(task);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while editing the task: {ex.Message}");
            }
        }
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var task = _taskRepository.GetTaskById(id);

                if (task == null)
                {
                    return NotFound();
                }

                return View(task);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the task to delete: {ex.Message}");
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _taskRepository.DeleteTaskConfirmed(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while deleting the task: {ex.Message}");
            }
        }
    }
}
