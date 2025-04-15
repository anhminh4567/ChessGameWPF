using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chest.GUI;
using Chest.Logic;
using Chest.Logic.Boards;
using Chest.Logic.Boards.@abstract;
using Chest.Logic.Boards.@abstract.schemes;
using Chest.Logic.Moves;
using Chest.Logic.Moves.@abstract;
using Chest.Logic.Pieces.@abstract;
using Newtonsoft.Json;
namespace ChestGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private GameState _gameState;
		private readonly Image[,] _pieceImages = new Image[8, 8];
		private readonly Rectangle[,] _highlightedSquares = new Rectangle[8, 8];
		private readonly Dictionary<Position, Move> _moveCache = new();
		private List<Player> _players = new();
		private IBoardInitScheme _boardInitScheme;
		private Position? _selectedPostion = null;

		public GameState CurrentGameState
		{
			get => _gameState;
			private set => _gameState = value;
		}

		public MainWindow()
		{
			InitializeComponent();
			InitializeBoard();

			//IBoardInitScheme scheme = new NormalInit();
			//IBoardInitScheme scheme = new CheckMateInit_No2();
			//IBoardInitScheme scheme = new PawnPromotionInit_No2();
			//IBoardInitScheme scheme = new CastleW_No1();
			//IBoardInitScheme scheme = new CastleB_No1();
			//IBoardInitScheme scheme = new CastleW_No2();
			//IBoardInitScheme scheme = new CastleW_No3();
			IBoardInitScheme scheme = new EnPassant_No1();


			_boardInitScheme = scheme;

			Board initialBoard = Board.Initial(scheme);

			Player whitePlayer = new Player(Chest.Logic.Color.White, "Mr.white");
			Player blackPlayer = new Player(Chest.Logic.Color.Black, "Mr.black");
			_players.AddRange([whitePlayer,blackPlayer]);
			//_gameState = new GameState(initialBoard, whitePlayer,blackPlayer);
			_gameState = new GameState(initialBoard, blackPlayer, whitePlayer );

			DrawBoard(initialBoard);
			SetCursor(_gameState.CurrentPlayer);

		}
		private void InitializeBoard()
		{
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					Image image = new Image();
					_pieceImages[row, col] = image;
					PieceGrid.Children.Add(image);

					Rectangle hightLightSquare = new();
					_highlightedSquares[row, col] = hightLightSquare;
					this.HightLightGrid.Children.Add(hightLightSquare);
				}
			}
		}
		private void DrawBoard(Board board)
		{
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					Piece piece = board[row, col];

					Image image = _pieceImages[row, col];

					image.Source = Images.GetImage(piece);
				}
			}
		}
		
		private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
#if DEBUG
			Console.WriteLine(sender == e.Source);
			Console.WriteLine(sender == e.OriginalSource);
#endif
			// if user is open menu, then ofcourse, should not move 
			if (IsMenuOnScreen()) 
			{
				return;
			}


			Point point = e.GetPosition(this.BoardGrid);
			Position pos = ToSquarePosition(point);

			if (_selectedPostion == null)
			{
				OnFromPositionSelected(pos);
			}
			else
			{
				OnToPositionSelected(pos);
			}
		}


		private void CacheMoves(IEnumerable<Move> moves)
		{
			_moveCache.Clear();
			foreach (var move in moves)
			{
				_moveCache[move.To] = move;
			}
		}
		private void ShowHighlightedSquares()
		{
			System.Windows.Media.Color color = Colors.Azure;
			foreach(Position to in _moveCache.Keys)
			{
				Rectangle hightLightSquare = _highlightedSquares[to.Row, to.Column];
				hightLightSquare.Fill = new SolidColorBrush(color);
			}
		}
		private void HideHighlightedSquares()
		{
			foreach (Position to in _moveCache.Keys)
			{
				_highlightedSquares[to.Row, to.Column].Fill = Brushes.Transparent;
			}
		}
		/// <summary>
		///the board is 8x8, so we time it with 8
		/// this is just some basic math
		/// the division beteween point and grid ( F ) , will only in range 0 <= F <= 1
		/// so for the situation with 8 grid, we just time it will 8 :	    0 <= F * 8 <= 8
		/// from this we Math.Floor(), get the row and column easily
		/// we floor instead of Ceilling(), because position start with 0 end with 7, 
		/// if we do it normally, with normal math we round it up ( since normally the square start called 1 not 0 )
		/// </summary>
		/// <param name="point"></param>
		/// <returns></returns>
		private Position ToSquarePosition( Point point)
		{
			int column = (int) Math.Floor( (point.X / BoardGrid.ActualWidth) * 8);
			int row = (int) Math.Floor( (point.Y / BoardGrid.ActualHeight * 8) ) ;
			return new Position(row, column);
		}
		private void OnFromPositionSelected(Position pos)
		{
			IEnumerable<Move> moves = _gameState.LegalMoveForPiece(pos);
			if (moves.Any()) {
				_selectedPostion = pos;
				CacheMoves(moves);
				ShowHighlightedSquares();
			}
		}
		private void HandlePromotion(Position from, Position to)
		{
			//show pawn at to positon, then display menu
			// then we re-draw the board SINCE this is not the final calculation of the board
			_pieceImages[to.Row, to.Column].Source = Images.GetImage(PieceType.Pawn,_gameState.CurrentPlayer.Color);
			_pieceImages[from.Row, from.Column].Source = null;

			PromotionMenu promotionMenu = new PromotionMenu(_gameState.CurrentPlayer);
			this.MenuContainer.Content = promotionMenu;
			promotionMenu.PieceSelected += pieceType =>
			{
				MenuContainer.Content = null;
				Move move = new PawnPromotionMove(from, to, pieceType);
				HandleMove(move);
			};
		}

		private void HandleMove(Move move)
		{
			_gameState.MakeMove(move); 
			DrawBoard(_gameState.ChessBoard);
			SetCursor(_gameState.CurrentPlayer);

			if (_gameState.IsGameOver())
			{
				ShowGameOver();
			}

		}
		private void OnToPositionSelected(Position pos)
		{
			_selectedPostion = null;
			HideHighlightedSquares();
			if(_moveCache.TryGetValue(pos, out Move move))
			{
				
				if(move.Type == MoveType.PawnPromotion)
				{
					HandlePromotion(move.From,move.To);
				}
				else
				{
					HandleMove(move);
				}
			}
		}

		
		private void SetCursor(Player player)
		{
			if(player.Color == Chest.Logic.Color.White)
			{
				this.Cursor = ChessCursors.WhiteCursor;
			}
			else
			{
				this.Cursor = ChessCursors.BlackCursor;
			}
		}

		private bool IsMenuOnScreen() 
		{
			return this.MenuContainer.Content != null;
		}

		private void ShowGameOver()
		{
			GameOverMenu gameOverMenu = new GameOverMenu(_gameState);
			this.MenuContainer.Content = gameOverMenu;
			gameOverMenu.OptionSelected += option =>
			{
				if (option == Option.Restart)
				{
					this.MenuContainer = null;
					RestartGame();
				}
				else
				{
					Application.Current.Shutdown();
				}
			};
		}

		private void RestartGame()
		{
			HideHighlightedSquares();
			_moveCache.Clear();
			Board board = Board.Initial(_boardInitScheme);
			_gameState = new GameState(board, _players[0], _players[1]);
			DrawBoard(_gameState.ChessBoard	);
			SetCursor(_gameState.CurrentPlayer);
		}
	}
}