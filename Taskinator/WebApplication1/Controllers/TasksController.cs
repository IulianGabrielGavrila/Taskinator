﻿using System;
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
            return _context.Tasks != null ?
                        View(await _context.Tasks.ToListAsync()) :
                        Problem("Entity set 'TaskinatorContext.Task'  is null.");
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
        public IActionResult Create([Bind("Name,Difficulty,Status,Board_ID,Creation_Date")] Task_Table task)
        {
            try
            {
                //if (ModelState.IsValid)

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

                return View(task);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the task to edit: {ex.Message}");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Creation_Date,Description,Task_id")] Task_Table task)
        {
            try
            {
                if (id != task.ID)
                {
                    return NotFound();
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