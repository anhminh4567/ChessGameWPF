using Chest.Logic.Boards.@abstract;
using Chest.Logic.Pieces;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Boards
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
		public static Board Initial(IBoardInitScheme initScheme)
		{
			Board board = new Board();
			//board.AddStartPieces();
			initScheme.Init(board);
			return board;
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
