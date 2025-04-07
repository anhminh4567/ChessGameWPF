using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves
{
	public class NormalMove : Move
	{
		public override MoveType Type { get; init; } = MoveType.Normal;
		public override Position From { get; init; }
		public override Position To { get; init; }

		public NormalMove(Position from, Position to)
		{
			From = from;
			To = to;
		}

		public override void Execute(Board board)
		{
			Piece piece = board[From];
			board[To] = piece;
			board[From] = null;
			piece.HasMoved = true;
		}
	}
}
