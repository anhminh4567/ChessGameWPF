using Chest.Logic.Boards;
using Chest.Logic.Moves.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves
{
	public class DoublePawnMove : Move
	{
		public override MoveType Type { get; init; } = MoveType.DoublePawn;
		public override Position From { get; init; }
		public override Position To { get; init; }

		private readonly Position _skippedPosition;

		public DoublePawnMove(Position from, Position to)
		{
			From = from;
			To = to;
			_skippedPosition = new Position((from.Row + to.Row) / 2, from.Column);
		}

		public override void Execute(Board board)
		{
			Color playerColor = board[From].Color;
			board.SetPawnSkipPosition(playerColor, _skippedPosition);
			new NormalMove(From, To).Execute(board);
		}
	}
}
