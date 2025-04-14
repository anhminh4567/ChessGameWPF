using Chest.Logic.Pieces.@abstract;
using Chest.Logic.Pieces;

namespace Chest.Logic.Boards.@abstract.schemes
{
	public class CheckMateInit_No2 : IBoardInitScheme
	{
		public void Init(Board board)
		{
			Dictionary<string, Piece> black = new()
			{
				{ nameof(Queen), new Queen(Color.Black) },
				{ nameof(King), new King(Color.Black) }
			};
			Dictionary<string, Piece> white = new()
			{
				{ nameof(Queen), new Queen(Color.White) },
				{ nameof(King), new King(Color.White) }
			};
			board[4,4] = black[nameof(King)];
			board[5,3] = black[nameof(Queen)];
			board[7,4] = white[nameof(King)];
		}
	}
}
