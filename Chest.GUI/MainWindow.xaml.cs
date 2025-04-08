using System.Text;
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
using Chest.Logic.Pieces.@abstract;
namespace ChestGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private GameState _gameState;
		private readonly Image[,] _pieceImages = new Image[8, 8];
		public MainWindow()
		{
			InitializeComponent();
			InitializeBoard();

			Board initialBoard = Board.Initial();

			Player whitePlayer = new Player(Chest.Logic.Color.White, "Mr.white");
			Player blackPlayer = new Player(Chest.Logic.Color.Black, "Mr.black");

			_gameState = new GameState(initialBoard, whitePlayer,blackPlayer);

			DrawBoard(initialBoard);
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
		private void btnCheckBoardSquare_Click(object sender, RoutedEventArgs e)
		{
			
		}

	}
}