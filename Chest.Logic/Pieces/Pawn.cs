using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Pieces
{
	public class Pawn : Piece
	{
		
		public override Color Color { get; init; }
		public override PieceType Type { get; init; } = PieceType.Pawn;
		public Pawn (Color color)
		{
			Color = color;
		}

		public override Piece Copy()
		{
			Pawn copy = new Pawn(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
	}

}
