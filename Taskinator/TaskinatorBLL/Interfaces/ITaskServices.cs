using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorBLL.Interfaces
{
    public interface ITaskService
    {
        Task_Table GetTaskById(int? id);
        Task<List<Task_Table>> Index();
        int CreateTask(Task_Table task);
        List<Task_Table> GetTasksByBoardId(int? boardId);
        Task_Table EditTask(int? id);
        Task_Table DeleteTask(int? id);
        int DeleteConfirmedTask(int id);
    }
}
