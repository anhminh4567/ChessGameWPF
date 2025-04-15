using Chest.Logic.Pieces.@abstract;
using Chest.Logic.Pieces;

namespace Chest.Logic.Boards.@abstract.schemes
{
	/// <summary>
	/// cannot castle sincee check by the black queen
	/// </summary>
	public class CastleW_No3 : IBoardInitScheme
	{
		public void Init(Board board)
		{
			Dictionary<string, Piece> black = new()
			{
				 {nameof(Rook), new Rook(Color.Black) },
				{ nameof(Pawn), new Pawn(Color.Black) },
				{ nameof(Knight), new Knight(Color.Black) },
				{ nameof(Bishop), new Bishop(Color.Black) },
				{ nameof(Queen), new Queen(Color.Black) },
				{ nameof(King), new King(Color.Black) }
			};
			Dictionary<string, Piece> white = new()
			{
				{ nameof(Rook), new Rook(Color.White) },
				{ nameof(Pawn), new Pawn(Color.White) },
				{ nameof(Knight), new Knight(Color.White) },
				{ nameof(Bishop), new Bishop(Color.White) },
				{ nameof(Queen), new Queen(Color.White) },
				{ nameof(King), new King(Color.White) }
			};
			board[0, 0] = black[nameof(Rook)];
			board[0, 4] = black[nameof(King)];

			board[7,0] = black[nameof(Queen)];
			board[7, 7] = white[nameof(Rook)];
			board[7, 4] = white[nameof(King)];
		}
	}
}
