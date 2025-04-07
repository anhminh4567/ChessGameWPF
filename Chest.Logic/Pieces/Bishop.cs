using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Pieces
{
    public class Bishop : Piece
	{
		public override Color Color { get; init; }
		public override PieceType Type { get; init; } = PieceType.Bishop;
		public Bishop(Color color)
		{
			Color = color;
		}
		public override Piece Copy()
		{
			Bishop copy = new Bishop(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
	} 
    
}
