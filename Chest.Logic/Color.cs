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
	public static class ColorExtensions
	{
		public static Color Opposite(this Color color)
		{
			return color == Color.White ? Color.Black : Color.White;
		}
	}
}
