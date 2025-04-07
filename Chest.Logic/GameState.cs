using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public class GameState
    {
        public Board ChessBoard { get; init; } = Board.Initial();
        public Player CurrentPlayer { get; private set; }

		public GameState(Board chessBoard, Player currentPlayer)
		{
			ChessBoard = chessBoard;
			CurrentPlayer = currentPlayer;
		}
	}
}
