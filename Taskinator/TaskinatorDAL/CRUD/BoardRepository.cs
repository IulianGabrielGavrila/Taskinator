using System;
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
    public class BoardRepository :IBoardRepository
    {
        private readonly TaskinatorMVCContext _context;
        private readonly TaskRepository _taskRepository;
        public BoardRepository(TaskinatorMVCContext context)
        {
            _context = context;
        }

        public Task<List<Board>> Index()
        {
            var boards = _context.Boards.ToListAsync();
            if (boards == null)
            {
                throw new Exception("TaskinatorContext.Boards is null.");
            }
            return boards;
        }
        public Board GetBoardById(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                throw new ArgumentNullException();
            }

            Board board = _context.Boards
                .FirstOrDefault(m => m.ID == id);


            return board;
        }
        public int CreateBoard(Board board)
        {

            _context.Add(board);
            _context.SaveChanges();
            return board.ID;


        }
        public Board GetBoardEdit(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                throw new ArgumentNullException();
            }

            var board = _context.Boards.Find(id);
            if (board == null)
            {
                throw new ArgumentNullException();
            }
            return board;
        }
        public int EditBoard(Board board, int? id)
        {
            if (id != board.ID)
            {
                throw new InvalidOperationException();
            }


            try
            {
                _context.Update(board);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(board.ID))
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    throw;
                }
            }
            return board.ID;
        }

        public Board GetDeleteBoard(int? id)
        {
            if (id == null || _context.Boards == null)
            {
                throw new ArgumentNullException();
            }

            var board = _context.Boards
                .FirstOrDefault(m => m.ID == id);
            if (board == null)
            {
                throw new ArgumentNullException();
            }

            return board;
        }

    

        public int DeleteBoardConfirmed(int? id)
        {
            if (_context.Boards == null)
            {
                throw new InvalidOperationException("Entity set 'TaskinatorContext.Board'  is null.");
            }
            var board = _context.Boards.Find(id);
            if (board != null)
            {
                _context.Boards.Remove(board);
            }

            _context.SaveChanges();
            return board.ID;
        }
        private bool BoardExists(int id)
        {
            return (_context.Boards?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
