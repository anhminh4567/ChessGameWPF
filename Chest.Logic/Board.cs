using Chest.Logic.Pieces;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
	public class Board
	{
		private Piece[,] _pieces = new Piece[8, 8];
		public Piece this[int row, int column] 
		{
			get => _pieces[row, column];
			set
			{
				if (!IsValidPosition(row, column))
					throw new IndexOutOfRangeException("Invalid board position");
				_pieces[row, column] = value;
			}
		}
		public Piece this[Position position]
		{
			get => this[position.Row, position.Column];
			set => this[position.Row, position.Column] = value;
		}
		public static Board Initial()
		{
			Board board = new Board();
			board.AddStartPieces();
			return board;
		}

		private void AddStartPieces()
		{
			Dictionary<string, Piece> black = new()
			{
				 {nameof(Rook), new Rook(Color.Black) },
				{ nameof(Pawn), new Pawn(Color.Black) },
				{ nameof(Knight), new Knight(Color.Black) },
				{ nameof(Bishop), new Bishop(Color.Black) },
				{ nameof(Queen), new Queen(Color.Black) },
				{ nameof(King), new King(Color.Black) }
			};
			Dictionary<string, Piece> white = new()
			{
				{ nameof(Rook), new Rook(Color.White) },
				{ nameof(Pawn), new Pawn(Color.White) },
				{ nameof(Knight), new Knight(Color.White) },
				{ nameof(Bishop), new Bishop(Color.White) },
				{ nameof(Queen), new Queen(Color.White) },
				{ nameof(King), new King(Color.White) }
			};
			//black init
			this[0, 0] = black[nameof(Rook)];
			this[0, 1] = black[nameof(Knight)];
			this[0, 2] = black[nameof(Bishop)];
			this[0, 3] = black[nameof(Queen)];
			this[0, 4] = black[nameof(King)];
			this[0,5] = black[nameof(Bishop)];
			this[0, 6] = black[nameof(Knight)];
			this[0,7] = black[nameof(Rook)];
			for (int i = 0; i < 8; i++)
			{
				this[1, i] = black[nameof(Pawn)];
			}
			//white init
			this[7, 0] = white[nameof(Rook)];
			this[7, 1] = white[nameof(Knight)];
			this[7, 2] = white[nameof(Bishop)];
			this[7, 3] = white[nameof(Queen)];
			this[7, 4] = white[nameof(King)];
			this[7, 5] = white[nameof(Bishop)];
			this[7, 6] = white[nameof(Knight)];
			this[7, 7] = white[nameof(Rook)];
			for (int i = 0; i < 8; i++)
			{
				this[6, i] = white[nameof(Pawn)];
			}
		}

		public static bool IsValidPosition(int row, int column)
		{
			return row >= 0 && row < 8 && column >= 0 && column < 8;
		}
		public static bool IsValidPosition(Position position)
		{
			return IsValidPosition(position.Row, position.Column);
		}
		public bool IsEmpty(Position position)
		{
			return this[position] == null;
		}
		/// <summary>
		/// this function return all the positon that have a piece in them
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Position> GetPiecePosition()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					Position pos = new Position(i, j);
					if (!IsEmpty(pos))
						yield return pos;
				}
			}
		}
		public IEnumerable<Position> GetPiecePositionForPlayer(Player player)
		{
			return GetPiecePosition().Where(pos => this[pos].Color == player.Color);
		}
		/// <summary>
		/// check if the player's kinig is in cheeck
		/// </summary>
		/// <param name="player">player you want to check</param>
		/// <param name="opponent"> opponent player to check against</param>
		/// <returns></returns>
		public bool IsInCheck(Player player, Player opponent)
		{
			IEnumerable<Position> opponentPieces = GetPiecePositionForPlayer(opponent);
			return opponentPieces.Any(pos =>
			{
				return this[pos].CanCaptureOpponentKing(pos, this);
			});
		}
		public Board Copy()
		{
			Board newBoard = new();
			foreach(Position pos in GetPiecePosition())
			{
				newBoard[pos] = this[pos].Copy();
			}
			return newBoard;
		}
	}
}
