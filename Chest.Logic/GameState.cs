using Chest.Logic.Boards;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public class GameState 
    {
		private Player[] _players = new Player[2];


		public Board ChessBoard { get; init; }
        public Player CurrentPlayer { get; private set; }

		public Result? GameResult { get; private set; } = null; 

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
			IEnumerable<Move> possibleMoves = piece.GetMoves(position, ChessBoard);
			return possibleMoves.Where(move => move.IsLegal(ChessBoard, CurrentPlayer, GetOpponent() ));
		}
		public void MakeMove(Move moveTo)
		{
			// this is to make sure, the enpassant only happen once right after the pawn move Doublee
			// after that forget the skip positoin
			// if B move Double ==> store the skip position in Execute(ChessBoard)
			// then W turn, this time, the skip position is not reseet for B 
			// white Execute(ChessBoard) and did not do EnPassantMove.cs
			// ==> next time the black move, the skip position is SET TO NULL ==> FORGET
			// ==> WHITE move again, and no ENPASSANT is allowed
			ChessBoard.SetPawnSkipPosition(CurrentPlayer.Color, null);

			moveTo.Execute(ChessBoard);

			CurrentPlayer = _players.Where(p => p.Color != CurrentPlayer.Color).First();
			// after move check if we win or draw
			CheckForGameOver();
		}
		public Player GetOpponent()
		{
			return _players.Where(p => p.Color != CurrentPlayer.Color).First();
		}
		public IEnumerable<Move> AllLegalMovesForPlayer(Player player)
		{
			IEnumerable<Move> moveCandidiates = ChessBoard.GetPiecePositionForPlayer(player)
				.SelectMany(pos => {
					Piece piece = ChessBoard[pos];
					return piece.GetMoves(pos, ChessBoard);
				});
			return moveCandidiates.Where(move => move.IsLegal(ChessBoard, player, GetOpponent()));
		}

		private void CheckForGameOver()
		{
			if(  AllLegalMovesForPlayer(CurrentPlayer).Any() == false)
			{
				if(ChessBoard.IsInCheck(CurrentPlayer, GetOpponent()))
				{
					var opponent = GetOpponent();
					GameResult = Result.Win(opponent);
				}
				else
				{
					GameResult = Result.Draw(EndReason.Stalemate);
				}
			}
		}
		public bool IsGameOver()
		{
			return GameResult != null;
		}
	}
}
