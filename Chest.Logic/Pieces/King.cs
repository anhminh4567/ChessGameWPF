using Chest.Logic.Boards;
using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;

namespace Chest.Logic.Pieces
{
	public class King : Piece
	{
		public override PieceType Type { get; init; } = PieceType.King;
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
		public King(Color color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			King copy = new King(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			foreach (Position to in MovePositions(from, board))
			{
				yield return new NormalMove(from, to);
			}
		}
		private IEnumerable<Position> MovePositions(Position from, Board board)
		{
			foreach(Direction direction in _possibleDirection)
			{
				Position to = from + direction;
				if (!Board.IsValidPosition(to))
				{
					continue;
				}
				if (board.IsEmpty(to) || board[to].Color != this.Color)
				{
					yield return to;
				}
			}
		}
	}
}
