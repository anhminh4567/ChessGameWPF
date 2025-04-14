using Chest.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
	/// Interaction logic for GameOverMenu.xaml
	/// </summary>
	public partial class GameOverMenu : UserControl
	{
		public event Action<Option> OptionSelected;
		public GameOverMenu(GameState finalGameState)
		{
			InitializeComponent();
			
			Result gameResult = finalGameState.GameResult!;
			WinnerText.Text = GetWinnerText(gameResult.Winner);
			ReasonText.Text = GetReasonText(gameResult.Reason, finalGameState.CurrentPlayer);
		}
		private static string GetWinnerText(Player? winner)
		{
			if (winner == null) 
			{
				return "It's a draw !!";
			}
			return $"{winner.Color.ToString()} player ( {winner.Name} ) wins";
		}
		private static string GetReasonText(EndReason reason, Player currentPlayer)
		{
			return reason switch
			{
				EndReason.Stalemate => $"Stalemate !! - {currentPlayer.Color.ToString()} can't move",
				EndReason.Checkmate => $"Checkmate ! - {currentPlayer.Color.ToString()} win",
				EndReason.InsufficientMaterial => $"Insufficient matterial",
				EndReason.FiftyMoveRule => $"Fifty moves rule violateed",
				EndReason.ThreefoldRepetition => "Three fold repetition violated",
				_ => ""
			};
		}
		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected.Invoke(Option.Exit);
        }

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected.Invoke(Option.Exit);
		}

	}
}
