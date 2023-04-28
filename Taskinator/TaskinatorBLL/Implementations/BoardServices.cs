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
    public class BoardBL : IBoardService
    {
        private readonly BoardRepository boardRepository;

        public BoardBL(TaskinatorMVCContext context)
        {
            boardRepository = new BoardRepository(context);
        }

        public Board GetBoardById(int? id)
        {
            return boardRepository.GetBoardById(id);
        }

        public int CreateBoard(Board board)
        {
            return boardRepository.CreateBoard(board);
        }

        public Board EditBoard(int? id)
        {
            return boardRepository.GetBoardEdit(id);
        }

        public int EditBoard(Board board, int id)
        {
            return boardRepository.EditBoard(board, id);
        }

        public Board DeleteBoard(int? id)
        {
            return boardRepository.GetDeleteBoard(id);
        }

        public int DeleteConfirmedBoard(int id)
        {
            return boardRepository.DeleteBoardConfirmed(id);
        }
    }
}
