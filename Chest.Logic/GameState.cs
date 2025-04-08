using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public class GameState
    {
		private Player[] _players = new Player[2];

		public Board ChessBoard { get; init; } = Board.Initial();
        public Player CurrentPlayer { get; private set; }

		public GameState(Board chessBoard,Player starterPlayer, Player otherPlayer)
		{
			ChessBoard = chessBoard;
			CurrentPlayer = starterPlayer;
			_players[0] = starterPlayer;
			_players[1] = otherPlayer;
		}

		public IEnumerable<Move> LegalMoveForPiece(Position position)
		{
			if(ChessBoard.IsEmpty(position) || ChessBoard[position].Color != CurrentPlayer.Color)
			{
				return Enumerable.Empty<Move>();
			}

			Piece piece = ChessBoard[position];
			return piece.GetMoves(position, ChessBoard);
		}
		public void MakeMove(Move moveTo)
		{
			moveTo.Execute(ChessBoard);

			CurrentPlayer = _players.Where(p => p != CurrentPlayer).First();
		}
	}
}
