using Chest.Logic.Boards.@abstract;
using Chest.Logic.Pieces.@abstract;
using Chest.Logic.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Boards.@abstract.schemes
{
	/// <summary>
	/// This class is used to initialize the board with a checkmate position
	/// for video part 9 https://www.youtube.com/watch?v=oJpWFktFky8&list=PLFk1_lkqT8MahHPi40ON-jyo5wiqnyHsL&index=9
	/// </summary>
	public class CheckMateInit_No1 : IBoardInitScheme
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

			board[0,4] = black[nameof(King)];
			board[2,5] = white[nameof(Queen)];
			board[5,5] = white[nameof(Bishop)];
			board[7,6] = white[nameof(King)];
		}
	}
}
