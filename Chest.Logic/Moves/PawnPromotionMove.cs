using Chest.Logic.Boards;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves
{
	public class PawnPromotionMove : Move
	{
		public override MoveType Type { get; init; }
		public override Position From { get; init; }
		public override Position To { get; init; }
		public PieceType NewPieceType { get; init; }
		public PawnPromotionMove(Position from, Position to, PieceType newPieceType)
		{
			From = from;
			To = to;
			NewPieceType = newPieceType;
			Type = MoveType.PawnPromotion;
		}
		private Piece CreatePromotionPiece(Color color)
		{
			return NewPieceType switch
			{
				PieceType.Queen => new Queen(color),
				PieceType.Rook => new Rook(color),
				PieceType.Knight => new Knight(color),
				PieceType.Bishop => new Bishop(color),
				_ => new Queen(color),
			};
		}
		public override void Execute(Board board)
		{
			Piece pawn = board[From];
			board[From] = null;

			Piece promotionPiece = CreatePromotionPiece(pawn.Color);
			// hasMoved == true : since this is the pawn promotion, after promotion
			// the piece is considered to have moved
			promotionPiece.HasMoved = true;
			board[To] = promotionPiece;
		}
	}
}
