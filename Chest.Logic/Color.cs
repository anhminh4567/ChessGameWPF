using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public enum Color
    {
		None,
		White,
		Black
	}
	public static class ColorExtension
	{
		public static Color Opponent(this Color color)
		{
			return color switch
			{
				Color.White => Color.Black,
				Color.Black => Color.White,
				_ => Color.None
			};
		}
	}
}
