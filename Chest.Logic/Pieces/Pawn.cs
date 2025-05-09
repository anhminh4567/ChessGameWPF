﻿using Chest.Logic.Boards;
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
	public class Pawn : Piece
	{
		
		public override Color Color { get; init; }
		public override PieceType Type { get; init; } = PieceType.Pawn;
		private readonly Direction _forward;

		
		public Pawn (Color color)
		{
			Color = color;
			// set direction if white or black
			if(color == Color.White)
				_forward = Direction.North;
			else
				_forward = Direction.South;
			

		}
		private static IEnumerable<Move> PromotionMoves(Position from, Position to)
		{
			yield return new PawnPromotionMove(from, to, PieceType.Queen);
			yield return new PawnPromotionMove(from, to, PieceType.Rook);
			yield return new PawnPromotionMove(from, to, PieceType.Knight);
			yield return new PawnPromotionMove(from, to, PieceType.Bishop);
		}

		public override Piece Copy()
		{
			Pawn copy = new Pawn(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			IEnumerable<Move> possibleMoves =  ForwardMoves(from, board)
				.Concat(
				DiagonalMoves(from, board));
			return possibleMoves;
		}
		private static bool CanMoveTo(Position pos, Board board)
		{
			// pawns can only move if the pos is not occupied by any piece ( if infront have any piece, stop )
			return Board.IsValidPosition(pos) && board.IsEmpty(pos);
		}
		private bool CanCaptureAt(Position pos, Board board)
		{
			if(! Board.IsValidPosition(pos) ||  board.IsEmpty(pos) )
			{
				return false;
			}
			return board[pos].Color != Color;
		}
		/// <summary>
		/// it returns all the possible moves for the pawn can make ( mostly 1 or 2 if it is the start of the game )
		/// and no piece is infron
		/// </summary>
		/// <param name="from"> current position</param>
		/// <param name="board"> board</param>
		/// <returns>alll possible front move</returns>
		private IEnumerable<Move> ForwardMoves(Position from, Board board)
		{
			Position oneMovePosition = from + _forward;
			if(CanMoveTo(oneMovePosition, board))
			{
				if(oneMovePosition.Row == 0 || oneMovePosition.Row == 7)
				{
					// if the pawn is at the end of the board, it can be promoted
					foreach (Move move in PromotionMoves(from, oneMovePosition))
					{
						yield return move;
					}
				}
				else
				{
					yield return new NormalMove(from, oneMovePosition);
					// check if it can move forward, ONLY WHEN IT FIRST MOVE
				}
				Position twoMovePosition = oneMovePosition + _forward;

				if (!HasMoved && CanMoveTo(twoMovePosition, board))
				{
					yield return new DoublePawnMove(from, twoMovePosition);
				}
			}
		}
		/// <summary>
		/// it returns all the possible diagonal moves for the pawn can make, since pawn can move
		/// ONLY IF THERE IS AN ENEMY PIECE IN THE DIAGONAL POSITION
		/// </summary>
		/// <param name="from"></param>
		/// <param name="board"></param>
		/// <returns>Possible Diagonal Move ( when there is opponent piece )</returns>
		private IEnumerable<Move> DiagonalMoves(Position from, Board board)
		{
			foreach(Direction dir in new Direction[] { Direction.East, Direction.West })
			{
				// diagonal is basically go forward and left or right
				Position to = from + _forward + dir;

				// we also check for the poisiontoin, to see if that position is skipped by opoonent pawn
				// if so we can do En Passant MOVE
				Color opponentColor = ColorExtensions.Opposite(this.Color);
				if (to == board.GetPawnSkipPosition(opponentColor))
				{
					yield return new EnPassantMove(from, to);
				}


				if (CanCaptureAt(to, board))
				{
					if (to.Row == 0 || to.Row == 7)
					{
						// if the pawn is at the end of the board, it can be promoted
						foreach (Move move in PromotionMoves(from, to))
						{
							yield return move;
						}
					}
					else
					{
						yield return new NormalMove(from, to);
					}
				}
			}
		}
		public override bool CanCaptureOpponentKing(Position from, Board board)
		{
			return DiagonalMoves(from, board)
				.Any(move => board[move.To] != null && board[move.To].Type == PieceType.King);
		}
	}

}
