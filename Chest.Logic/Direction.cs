using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic
{
    public class Direction
    {
		/// <summary>
		/// Direction go from top down, left to right, start with 0 - 7
		/// So in this case Go to the North ( go up ) means Row - 1 since the top is 0
		/// so the direction is (-1,0) ( which mean if we have a direction, choose go north, the row will -1 )
		/// </summary>
		public static readonly Direction North = new Direction(-1,0);
		public static readonly Direction South = new Direction(1, 0);
		public static readonly Direction West = new Direction(0, -1);
		public static readonly Direction East = new Direction(0, 1);

		public static readonly Direction NorthWest = North + West;
		public static readonly Direction NorthEast = North + East;
		public static readonly Direction SouthWest = South + West;
		public static readonly Direction SouthEast = South + East;


		public int RowDelta { get; set; }
        public int ColumnDelta { get; set; }
        public Direction(int rowDelta, int columnDelta)
		{
			RowDelta = rowDelta;
			ColumnDelta = columnDelta;
		}
		public static Direction operator +(Direction direction_1, Direction direction_2)
		{
			return new Direction(direction_1.RowDelta + direction_2.RowDelta,
				direction_1.ColumnDelta + direction_2.ColumnDelta);
		}
		// multiply the direction by a scalar
		public static Direction operator *(int scalar, Direction direction)
		{
			return new Direction(scalar * direction.RowDelta , scalar * direction.ColumnDelta);
		}

	}
}
