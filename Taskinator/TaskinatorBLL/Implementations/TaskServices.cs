using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.Models;
using TaskinatorBLL.Interfaces;

namespace TaskinatorBLL.Implementations
{
    public class TaskBL :ITaskService
    {
        private readonly TaskRepository taskRepository;

        public TaskBL(TaskinatorMVCContext context)
        {
            taskRepository = new TaskRepository(context);
        }

        public Task_Table GetTaskById(int? id)
        {
            return taskRepository.GetTaskById(id);
        }

        public int CreateTask(Task_Table task)
        {
            return taskRepository.CreateTask(task);
        }

        public Task_Table EditTask(int? id)
        {
            return taskRepository.GetTaskById(id);
        }

        public int EditTask(Task_Table task, int id)
        {
            return taskRepository.EditTask(task, id);
        }

        public Task_Table DeleteTask(int? id)
        {
            return taskRepository.GetTaskById(id);
        }

        public int DeleteConfirmedTask(int id)
        {
            return taskRepository.DeleteTaskConfirmed(id);
        }
    }
}
