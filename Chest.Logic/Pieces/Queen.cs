using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;

namespace Chest.Logic.Pieces
{
	public class Queen : Piece
	{
		public override PieceType Type { get; init; } = PieceType.Queen;
		public override Color Color { get; init; }
		private static readonly Direction[] _possibleDirection = new Direction[]
		{
			Direction.North,
			Direction.South,
			Direction.East,
			Direction.West,
			Direction.NorthEast,
			Direction.NorthWest,
			Direction.SouthEast,
			Direction.SouthWest
		};
		public Queen(Color color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Queen copy = new Queen(Color);
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
