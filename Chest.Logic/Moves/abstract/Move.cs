using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves.@abstract
{
    public abstract class Move
    {
        public abstract MoveType Type { get; init ; }
        public abstract Position From { get; init ; }
        public abstract Position To { get; init ; }
        public abstract void Execute(Board board);
    }
}
