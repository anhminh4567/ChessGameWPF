using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest.Logic.Moves.@abstract
{
    public enum MoveType
    {
        Normal,
        CastleKingSide, 
        CastleQueenSide,
        DoublePawn,
        EnPassant, // overtake by going behind a piece 
        PawnPromotion,
    }
}
