using ChestLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
	/// <summary>
	/// poisiont go from top down, left to right, start with 0 - 7
	/// |-----------> Row
	/// | # 0 1 2 3 4 5 6 7
	/// | 0 
	/// | 1 
	/// | 2 
	/// | 3
	///  ....
	/// the (0,0) is white
	/// the (0,1) is black
	/// using that the sum of ROW and COLUMN
	/// ==> Even is WHITE 
	/// ==> Odd is BLACK 
	/// </summary>
	public class Position
    {
        public Position (int row, int column)
		{
			Row = row;
			Column = column;
		}
		public int Row { get; set; }
        public int Column { get; set; }

		public override int GetHashCode()
		{
			return HashCode.Combine(Row, Column);
		}

		public override bool Equals(object? obj)
		{
			return obj is Position position &&
				   Row == position.Row &&
				   Column == position.Column;
		}
		public Player SquareColor()
		{
			if( ( Row + Column) % 2 == 0)
			{
				return Player.White;
			}
			else
			{
				return Player.Black;
			}
		}

		public static bool operator ==(Position? left, Position? right)
		{
			return EqualityComparer<Position>.Default.Equals(left, right);
		}

		public static bool operator !=(Position? left, Position? right)
		{
			return !(left == right);
		}

		public static Position operator +(Position position, Direction direction)
		{
			return new Position(position.Row + direction.RowDelta, position.Column + direction.ColumnDelta);
		}
	}
}
