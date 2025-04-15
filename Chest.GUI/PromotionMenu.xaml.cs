using Chest.Logic;
using Chest.Logic.Pieces.@abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chest.GUI
{
	/// <summary>
	/// Interaction logic for PromotionMenu.xaml
	/// </summary>
	public partial class PromotionMenu : UserControl
	{
		public event Action<PieceType> PieceSelected;
		public PromotionMenu(Player currentPlayerToPromote)
		{
			InitializeComponent();

			this.QueenImg.Source = Images.GetImage(PieceType.Queen, currentPlayerToPromote.Color);
			this.BishopImg.Source = Images.GetImage(PieceType.Bishop, currentPlayerToPromote.Color);
			this.RookImg.Source = Images.GetImage(PieceType.Rook, currentPlayerToPromote.Color);
			this.KnightImg.Source = Images.GetImage(PieceType.Knight, currentPlayerToPromote.Color);
		}

		private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
		{
			PieceSelected.Invoke(PieceType.Queen);
		}

		private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
		{
			PieceSelected.Invoke(PieceType.Bishop);
		}

		private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
		{
			PieceSelected.Invoke(PieceType.Rook);
		}

		private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
		{
			PieceSelected.Invoke(PieceType.Knight);
		}
	}
}
