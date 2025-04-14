using Chest.Logic.Boards;
using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Pieces
{
	public class Rook : Piece
	{
		public override PieceType Type { get; init; } = PieceType.Rook;
		public override Color Color { get; init; }
		private static readonly Direction[] _possibleDirection = new Direction[]
		{
			Direction.North,
			Direction.South,
			Direction.East,
			Direction.West
		};
		public Rook(Color color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Rook copy = new Rook(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			var possiblePositions = MovePositionInDirection(from, board, _possibleDirection);
			return possiblePositions.Select(pos => new NormalMove(from, pos));
		}
	}
}
