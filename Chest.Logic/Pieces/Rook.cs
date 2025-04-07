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
	}
}
