using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chest.Logic;
using Chest.Logic.Pieces.@abstract;
namespace Chest.GUI
{
	internal static class Images
	{
		private static readonly Dictionary<PieceType, ImageSource> _whiteSources = new()
		{
			{ PieceType.Pawn, LoadImageSource("Assets/PawnW.png")  },
			{ PieceType.Rook, LoadImageSource("Assets/RookW.png")  },
			{ PieceType.Knight, LoadImageSource("Assets/KnightW.png")  },
			{ PieceType.Bishop, LoadImageSource("Assets/BishopW.png")  },
			{ PieceType.Queen, LoadImageSource("Assets/QueenW.png")  },
			{ PieceType.King, LoadImageSource("Assets/KingW.png")  }
		};
		private static readonly Dictionary<PieceType, ImageSource> _blackSources = new()
		{
			{ PieceType.Pawn, LoadImageSource("Assets/PawnB.png")  },
			{ PieceType.Rook, LoadImageSource("Assets/RookB.png")  },
			{ PieceType.Knight, LoadImageSource("Assets/KnightB.png")  },
			{ PieceType.Bishop, LoadImageSource("Assets/BishopB.png")  },
			{ PieceType.Queen, LoadImageSource("Assets/QueenB.png")  },
			{ PieceType.King, LoadImageSource("Assets/KingB.png")  }
		};
		private static ImageSource LoadImageSource(string relativeFilePath)
		{
			return new BitmapImage(new Uri(relativeFilePath, UriKind.Relative));
		}
		public static ImageSource GetImage(PieceType pieceType, Logic.Color color)
		{
			if (color == Chest.Logic.Color.White)
			{
				return _whiteSources[pieceType];
			}
			else if (color == Chest.Logic.Color.Black)
			{
				return _blackSources[pieceType];
			}
			else
			{
				return null;
			}
		}
		public static ImageSource GetImage(Piece piece) 
		{
			if(piece == null)
			{
				return null;
			}
			return GetImage(piece.Type, piece.Color);
		}
	}
}
