using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.ICRUD
{
    public interface IBoardEmployeeRepository
    {
        List<Board_Employee> GetEmployeesByBoard(int? boardId);
    }
}
