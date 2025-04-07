using Chest.Logic.Pieces.@abstract;

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
	}
}
