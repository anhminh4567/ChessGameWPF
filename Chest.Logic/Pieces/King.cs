using Chest.Logic.Boards;
using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;

namespace Chest.Logic.Pieces
{
	public class King : Piece
	{
		public override PieceType Type { get; init; } = PieceType.King;
		public override Color Color { get; init; }
		private static readonly Direction[] _possibleDirection = new Direction[]
		{
			Direction.North,
			Direction.South,
			Direction.East,
			Direction.West,
			Direction.NorthEast,
			Direction.NorthWest,
			Direction.SouthEast,
			Direction.SouthWest
		};
		public King(Color color)
		{
			Color = color;
		}
		/// <summary>
		/// Check if the rook is unmoved
		/// </summary>
		/// <param name="pos">the poistion to check if there is a ROOK piece </param>
		/// <param name="board">board</param>
		/// <returns></returns>
		private static bool IsUnmovedRook(Position pos, Board board)
		{
			if (board.IsEmpty(pos))
			{
				return false;
			}
			else
			{
				Piece piece = board[pos];
				if (piece.Type == PieceType.Rook && !piece.HasMoved)
				{
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// Check if the positon between the King and ROOK is empty for castling
		/// </summary>
		/// <param name="positions">all the position between king and ROOK</param>
		/// <param name="board">board</param>
		/// <returns></returns>
		private static bool AllEmpty(IEnumerable<Position> positions, Board board)
		{
			return positions.All(pos => board.IsEmpty(pos));
		}
		public override Piece Copy()
		{
			King copy = new King(Color);
			copy.HasMoved = HasMoved;
			return copy;
		}
		public override IEnumerable<Move> GetMoves(Position from, Board board)
		{
			foreach (Position to in MovePositions(from, board))
			{
				yield return new NormalMove(from, to);
			}
			if(CanCastleKingSide(from, board))
			{
				yield return new CastleMove(MoveType.CastleKingSide, from);
			}
			if(CanCastleQueenSide(from, board))
			{
				yield return new CastleMove(MoveType.CastleQueenSide, from);
			}
		}
		private IEnumerable<Position> MovePositions(Position from, Board board)
		{
			foreach(Direction direction in _possibleDirection)
			{
				Position to = from + direction;
				if (!Board.IsValidPosition(to))
				{
					continue;
				}
				if (board.IsEmpty(to) || board[to].Color != this.Color)
				{
					yield return to;
				}
			}
		}

		private bool CanCastleKingSide(Position from, Board board)
		{
			if(HasMoved)
			{
				return false;
			}
			Position rookSupposedPosition = new Position(from.Row, 7);
			Position[] piecesBetweenThem  =new Position[]
			{
				new (from.Row, 5),
				new (from.Row, 6)
			};
			return IsUnmovedRook(rookSupposedPosition, board) &&
				AllEmpty(piecesBetweenThem, board);
		}
		private bool CanCastleQueenSide(Position from, Board board)
		{
			if (HasMoved)
			{
				return false;
			}
			Position rookSupposedPosition = new Position(from.Row, 0);
			Position[] piecesBetweenThem = new Position[]
			{
				new (from.Row, 1),
				new (from.Row, 2),
				new (from.Row, 3)
			};
			return IsUnmovedRook(rookSupposedPosition, board) &&
				AllEmpty(piecesBetweenThem, board);
		}
	}
}
