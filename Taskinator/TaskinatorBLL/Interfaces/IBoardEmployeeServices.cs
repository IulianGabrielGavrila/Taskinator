using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorBLL.Interfaces
{
    public interface IBoardEmployeeServices
    {
        List<Board_Employee> GetEmployeesByBoard(int? boardId);
    }
}
