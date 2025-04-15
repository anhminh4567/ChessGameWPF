using Chest.Logic.Pieces.@abstract;
using Chest.Logic.Pieces;

namespace Chest.Logic.Boards.@abstract.schemes
{
	// same as no1, but for black side
	public class PawnPromotionInit_No2 : IBoardInitScheme
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
			//black init
			board[0, 0] = black[nameof(Rook)];
			board[0, 1] = black[nameof(Knight)];
			board[0, 2] = black[nameof(Bishop)];
			board[0, 3] = black[nameof(Queen)];
			board[0, 4] = black[nameof(King)];
			board[0, 5] = black[nameof(Bishop)];
			board[0, 6] = black[nameof(Knight)];
			board[0, 7] = black[nameof(Rook)];
			for (int i = 0; i < 8; i++)
			{
				board[1, i] = black[nameof(Pawn)];
			}
			//white init
			board[7, 0] = white[nameof(Rook)];
			board[7, 1] = white[nameof(Knight)];
			board[7, 2] = white[nameof(Bishop)];
			board[7, 3] = white[nameof(Queen)];
			board[7, 4] = white[nameof(King)];
			board[7, 5] = white[nameof(Bishop)];
			board[7, 6] = white[nameof(Knight)];
			board[7, 7] = white[nameof(Rook)];
			for (int i = 0; i < 8; i++)
			{
				board[6, i] = white[nameof(Pawn)];
			}
			//we init like NormalInit()
			// then we move the piece later

			Piece pawnB = board[1, 7];
			board[1, 7] = null;

			Piece knightW = board[7, 6];
			board[7, 6] = null;

			board[3, 2] = knightW;
			board[6, 6] = null;

			board[6,6] = pawnB;

		}
	}
}

