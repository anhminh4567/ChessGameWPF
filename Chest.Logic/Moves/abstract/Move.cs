using Chest.Logic.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves.@abstract
{
    public abstract class Move
    {
        public abstract MoveType Type { get; init ; }
        public abstract Position From { get; init ; }
        public abstract Position To { get; init ; }
        public abstract void Execute(Board board);
		/// <summary>
		/// check if the move is legal to be executed, by execute on the copied board
		/// this is not the most efficient way to check if the move is legal
        /// if adding bots need better check methods
        /// but for now it wont effect much
		/// </summary>
		/// <param name="board"></param>
		/// <param name="currentPlayer"></param>
		/// <param name="opponent"></param>
		/// <returns></returns>
		public virtual bool IsLegal(Board board, Player currentPlayer, Player opponent)
        {
            Board copiedBoard = board.Copy();
            Execute(copiedBoard);
            return !copiedBoard.IsInCheck(currentPlayer, opponent);
		}
    }
}
