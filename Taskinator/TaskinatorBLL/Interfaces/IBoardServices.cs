﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorBLL.Interfaces
{
    public interface IBoardService
    {
        Board GetBoardById(int? id);
        Task<List<Board>> Index();
        Task<List<Board>> InactiveIndex();
        int ReactivateBoard(Board board, int? id);
        int CreateBoard(Board board);
        Board EditBoard(int? id);
        Board DeleteBoard(int? id);
        int DeleteConfirmedBoard(int id);
    }
}
