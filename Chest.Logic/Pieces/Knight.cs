using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace Chest.Logic.Pieces
{
	public class Knight : Piece
	{
		public override PieceType Type { get; init; } = PieceType.Knight;
		public override Color Color { get; init; }
		public Knight(Color color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Knight copy = new Knight(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			return MovePositions(from, board)
				.Select(to => new NormalMove(from, to));
		}
		private IEnumerable<Position> MovePositions(Position from, Board board)
		{
			return PotentialToPosition(from)
				.Where(to => Board.IsValidPosition(to)
				&& (board.IsEmpty(to) || board[to].Color != this.Color));
		}
		private static IEnumerable<Position> PotentialToPosition(Position from)
		{
			// outer loop for the Vertical Direction
			foreach(Direction vertical in new Direction[] { Direction.North, Direction.West })
			{
				// inner loop for the Horizontal Direction
				foreach (Direction horizontal in new Direction[] { Direction.East, Direction.South })
				{
					yield return from + (2 * vertical) + horizontal;
					yield return from + (2 * horizontal) + vertical;
				}
			}
		}
		
	}
}
