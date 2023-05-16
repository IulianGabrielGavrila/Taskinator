using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.ICRUD;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.CRUD
{
    public class BoardEmployeeRepository : IBoardEmployeeRepository
    {
        private readonly TaskinatorMVCContext _context;
        private readonly EmployeeRepository _employeeRepository;
        private readonly BoardRepository _boardRepository;

        public BoardEmployeeRepository(TaskinatorMVCContext context, EmployeeRepository employeeRepository, BoardRepository boardRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _boardRepository = boardRepository;
        }

        public List<Board_Employee> GetEmployeesByBoard(int? board_id)
        {
            if (board_id == null || _context.Boards == null || _context.Employees == null)
            {
                throw new ArgumentNullException();
            }

            var board_employees = _context.board_Employees
                .Include(be => be.Employee) 
                .Where(be => be.Board.ID == (int)board_id)
                .ToList();

            return board_employees;
        }


    }
}
