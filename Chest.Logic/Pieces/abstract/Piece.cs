using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Pieces.@abstract
{
	/// <summary>
	/// Base class for all pieces in the game.
	/// all other pieces will inherit from this class
	/// </summary>
	public abstract class Piece
    {
        public abstract PieceType Type { get; init; }
		public abstract Color Color { get; init; }
		public bool HasMoved { get; set; } = false;
		public abstract Piece Copy();
	}
}
