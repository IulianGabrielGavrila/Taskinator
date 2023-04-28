using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorBLL.Implementations;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.ICRUD;
using TaskinatorDAL.Models;

namespace Taskinator.Controllers
{
    public class BoardsController : Controller
    {
        private readonly TaskinatorMVCContext _context;
        private readonly BoardRepository _boardRepository;
        public BoardsController(TaskinatorMVCContext context)
        {
            _context = context;
            _boardRepository = new BoardRepository(_context);
        }
        public async Task<IActionResult> Index()
        {
            return _context.Boards != null ?
                        View(await _context.Boards.ToListAsync()) :
                        Problem("Entity set 'TaskinatorContext.Board'  is null.");
        }
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var board = _boardRepository.GetBoardById(id);

                if (board == null)
                {
                    return NotFound();
                }

                return View(board);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving board details: {ex.Message}");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Creation_Date,Description,Task_id")] Board board)
        {
            try
            {
                //if (ModelState.IsValid)
                
                    _boardRepository.CreateBoard(board);
                    return RedirectToAction(nameof(Index));
                

                //return View(board);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while creating the board: {ex.Message}");
            }
        }
        
        public IActionResult GetBoardEdit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var board = _boardRepository.GetBoardById(id);

                if (board == null)
                {
                    return NotFound();
                }

                return View("/Views/Boards/Edit.cshtml");
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the board to edit: {ex.Message}");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Creation_Date,Description,Task_id")] Board board)
        {
            try
            {
                if (id != board.ID)
                {
                    return NotFound();
                }

                //if (ModelState.IsValid)
                {
                    _boardRepository.EditBoard(board, id);
                    return RedirectToAction(nameof(Index));
                }

                //return View(board);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while editing the board: {ex.Message}");
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

                var board = _boardRepository.GetBoardById(id);

                if (board == null)
                {
                    return NotFound();
                }

                return View(board);
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while retrieving the board to delete: {ex.Message}");
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _boardRepository.DeleteBoardConfirmed(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem($"An error occurred while deleting the board: {ex.Message}");
            }
        }
    }
}
