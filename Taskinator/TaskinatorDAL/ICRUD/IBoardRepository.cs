using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.ICRUD
{
    public interface IBoardRepository
    {
        Board GetBoardById(int? id);
        int CreateBoard(Board board);
        Board GetBoardEdit(int? id);
        int EditBoard(Board board, int? id);
        Board GetDeleteBoard(int? id);
        int DeleteBoardConfirmed(int? id);
    }
}
