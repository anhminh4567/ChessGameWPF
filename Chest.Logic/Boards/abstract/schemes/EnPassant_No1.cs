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
	/// enpassant test, with black first to test
	/// </summary>
	public class EnPassant_No1 : IBoardInitScheme
	{
		public void Init(Board board)
		{
			Dictionary<string, Piece> black = new()
			{
				{ nameof(Pawn), new Pawn(Color.Black) },
				{ nameof(King), new King(Color.Black) }
			};
			Dictionary<string, Piece> white = new()
			{
				{ nameof(Pawn), new Pawn(Color.White) },
				{ nameof(King), new King(Color.White) }
			};

			board[0,4] = black[nameof(King)];
			board[1, 1] = black[nameof(Pawn)];

			board[7,4] = white[nameof(King)];
			board[3,2] = white[nameof(Pawn)];
			board[3, 2].HasMoved = true;
		}
	}
}
