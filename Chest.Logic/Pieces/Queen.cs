using Chest.Logic.Pieces.@abstract;

namespace Chest.Logic.Pieces
{
	public class Queen : Piece
	{
		public override PieceType Type { get; init; } = PieceType.Queen;
		public override Color Color { get; init; }
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
	}
}
