using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
	/// <summary>
	/// Result of the game
	/// Winner is null if the game ended in a draw
	/// </summary>
	public class Result
	{
		public Player? Winner { get; init; }
		public EndReason Reason { get; init; }
		protected Result(Player? winner, EndReason reason)
		{
			Winner = winner;
			Reason = reason;
		}
		public static Result Win(Player player)
		{
			return new Result(player, EndReason.Checkmate);
		}
		public static Result Draw(EndReason reason)
		{
			return new Result(null, reason);
		}
	}
}
