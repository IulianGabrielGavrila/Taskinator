﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.ICRUD
{
    public interface ITaskRepositoty
    {
        Task_Table GetTaskById(int? id);
        Task<List<Task_Table>> Index();
        int CreateTask(Task_Table task);
        List<Task_Table> GetTasksByBoardId(int? boardId);
        Task_Table GetTaskEdit(int? id);
        int EditTask(Task_Table task, int? id);
        Task_Table GetDeleteTask(int? id);
        int DeleteTaskConfirmed(int? id);
    }
}
