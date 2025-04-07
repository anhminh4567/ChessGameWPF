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
    public class Bishop : Piece
	{
		public override Color Color { get; init; }
		public override PieceType Type { get; init; } = PieceType.Bishop;
		private static readonly Direction[] _possibleDirection = new Direction[]
		{
			Direction.NorthEast,
			Direction.NorthWest,
			Direction.SouthEast,
			Direction.SouthWest
		};
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
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			var possiblePositions = MovePositionInDirection(from, board, _possibleDirection);
			return possiblePositions.Select(pos => new NormalMove(from, pos));
		}
	} 
    
}
