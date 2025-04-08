using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public class Player
    {
        public Color Color { get; init; }
        public string Name { get; init; }
        public Player (Color color, string name)
		{
			Color = color;
			Name = name;
		}
		
	}
}
