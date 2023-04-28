using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.ICRUD;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.CRUD
{
    public class TaskRepository : ITaskRepositoty
    {
        private readonly TaskinatorMVCContext _context;
        public TaskRepository(TaskinatorMVCContext context)
        {
            _context = context;
        }
        public Task_Table GetTaskById(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                throw new ArgumentNullException();
            }

            Task_Table task = _context.Tasks
                .FirstOrDefault(m => m.ID == id);


            return task;
        }
        public int CreateTask(Task_Table task)
        {

            _context.Add(task);
            _context.SaveChanges();
            return task.ID;


        }
        public Task_Table GetTaskEdit(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                throw new ArgumentNullException();
            }

            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new ArgumentNullException();
            }
            return task;
        }
        public int EditTask(Task_Table task, int? id)
        {
            if (id != task.ID)
            {
                throw new InvalidOperationException();
            }


            try
            {
                _context.Update(task);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(task.ID))
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    throw;
                }
            }
            return task.ID;
        }

        public Task_Table GetDeleteTask(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                throw new ArgumentNullException();
            }

            var task = _context.Tasks
                .FirstOrDefault(m => m.ID == id);
            if (task == null)
            {
                throw new ArgumentNullException();
            }

            return task;
        }

        public int DeleteTaskConfirmed(int? id)
        {
            if (_context.Tasks == null)
            {
                throw new InvalidOperationException("Entity set 'TaskinatorContext.Task'  is null.");
            }
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }

            _context.SaveChanges();
            return task.ID;
        }
        private bool TaskExists(int id)
        {
            return (_context.Boards?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
