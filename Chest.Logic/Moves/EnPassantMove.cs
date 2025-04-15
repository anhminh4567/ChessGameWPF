using Chest.Logic.Boards;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves
{
	public class EnPassantMove : Move
	{
		public override MoveType Type { get; init; } = MoveType.EnPassant;
		public override Position From { get; init; }
		public override Position To { get; init; }

		private readonly Position _capturePosition;

		public EnPassantMove(Position from, Position to)
		{
			From = from;
			To = to;
			// Calculate the position of the captured pawn
			_capturePosition = new Position(from.Row, to.Column);
		}

		public override void Execute(Board board)
		{
			// move pawn normally
			new NormalMove(From, To).Execute(board);
			// remove captured pawn
			Piece piece = board[_capturePosition];
			if(piece.Type != PieceType.Pawn)
			{
				throw new InvalidOperationException("En Passant can only capture a pawn.");
			}
			board[_capturePosition] = null;
		}
	}
}
