using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;

namespace Chest.Logic.Pieces
{
	public class King : Piece
	{
		public override PieceType Type { get; init; } = PieceType.King;
		public override Color Color { get; init; }
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
			throw new NotImplementedException();
		}
	}
}
