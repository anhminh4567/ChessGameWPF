using Chest.Logic.Moves.@abstract;
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
		/// <summary>
		/// get all possible moves for this piece
		/// </summary>
		/// <param name="from"> the position the piece is currently in (CurrentPosition) </param>
		/// <param name="board"> the chest board </param>
		/// <returns>all possible moves by this piece in the position</returns>
		public abstract IEnumerable<Move> GetMoves(Position from, Board board);
		/// <summary>
		/// move the position in the direction you choose, for this piece in a position from the board
		/// </summary>
		/// <param name="from">Position you want</param>
		/// <param name="board">the board</param>
		/// <param name="dir">direction in which you want to check for possible moves</param>
		/// <returns>all possiible positoin the piece can move in the CHOOSEN DIRECTION [dir param]</returns>
		protected IEnumerable<Position> MovePositionInDirection(Position from, Board board, Direction dir)
		{
			// each loop, we will move in the direction of dir
			// and check if the position is valid
			// if it is valid, we will add it to the list of moves
			// then move the possition to the next pos in the direction
			for (Position pos = from + dir; Board.IsValidPosition(pos); pos += dir)
			{
				if (board.IsEmpty(pos))
				{
					yield return pos;
					continue;
				}
				// check if any piece is in the position then check if its enemy or us
				Piece piece = board[pos];
				// if the piece color is not the same as the current piece color ( not an ally )
				// then we can take it, so the position of that pieece is counted as valid move
				if (piece.Color != Color)
				{
					yield return pos;
				}
				yield break; // we break since if we take the piece, we can't move any further in this direction
			}
		}
		protected IEnumerable<Position> MovePositionInDirection(Position from, Board board, Direction[] dirs)
		{
			return dirs.SelectMany(dir => MovePositionInDirection(from, board, dir));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="from">the position of the piece that gonna threaten the king</param>
		/// <param name="board"></param>
		/// <returns></returns>
		public virtual bool CanCaptureOpponentKing(Position from, Board board)
		{
			bool canCapture = 
				GetMoves(from, board).Any(m => board[m.To] != null && board[m.To].Type == PieceType.King);
			return canCapture;
		}
	}
}
