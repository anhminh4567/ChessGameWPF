using Chest.Logic.Boards;
using Chest.Logic.Moves.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves
{
	/// <summary>
	/// CastleMove is a special move that allows the king to move two squares towards a rook, and the rook to move to the square next to the king.
	/// Constructor(), init the positoin for Rook and King to Move as NormaMove in Execute()
	/// </summary>
	public class CastleMove : Move
	{
		public override MoveType Type { get; init; }

		public override Position From { get; init; }

		public override Position To { get; init; }

		private readonly Direction _kingMoveDirection;
		private readonly Position _rookFromPosition;
		private readonly Position _rookToPosition;
		public CastleMove(MoveType type, Position kingPos)
		{
			Type = type;
			From = kingPos;
			// this basically init, the rook move and king move 
			// to be used for execute()
			if (Type == MoveType.CastleKingSide)
			{
				_kingMoveDirection = Direction.East;

				_rookFromPosition = new Position(kingPos.Row, 7);
				_rookToPosition = new Position(kingPos.Row, 5);

				To = kingPos + (2 * _kingMoveDirection);
			}
			else if (Type == MoveType.CastleQueenSide)
			{
				_kingMoveDirection = Direction.West;

				_rookFromPosition = new Position(kingPos.Row, 0);
				_rookToPosition = new Position(kingPos.Row, 3);

				To = kingPos + ( 2 * _kingMoveDirection);
			}
		}
		public override bool IsLegal(Board board, Player currentPlayer, Player opponent)
		{
			if(board.IsInCheck(currentPlayer, opponent))
			{
				return false;
			}
			Board copiedBoard = board.Copy();
			Position kingPosInCopy = From;
			// check if each move the king is in check, if so it is not legal
			for (int i = 0; i < 2; i++)
			{
				Move kingMoveCopied = new NormalMove(kingPosInCopy, kingPosInCopy + _kingMoveDirection);

				kingMoveCopied.Execute(copiedBoard);
				// after move the position is now the To from previous move
				kingPosInCopy = kingMoveCopied.To;

				if(copiedBoard.IsInCheck(currentPlayer, opponent))
				{
					return false;
				}
			}

			return true;
		}

		public override void Execute(Board board)
		{
			// execute move for king first
			Move kingMove = new NormalMove(From, To);
			kingMove.Execute(board);

			// execute move for rook
			Move rookMove = new NormalMove(_rookFromPosition, _rookToPosition);
			rookMove.Execute(board);

		}
	}
}
