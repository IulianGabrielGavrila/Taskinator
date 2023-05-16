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
    public class BoardEmployeeSerives : IBoardEmployeeServices
    {
        private readonly BoardEmployeeRepository boardEmployeeRepository;

        public BoardEmployeeSerives(TaskinatorMVCContext context)
        {
            boardEmployeeRepository = new BoardEmployeeRepository(context, new EmployeeRepository(context), new BoardRepository(context));
        }

        public List<Board_Employee> GetEmployeesByBoard(int? boardId)
        {
            return boardEmployeeRepository.GetEmployeesByBoard(boardId);
        }
    }

}

