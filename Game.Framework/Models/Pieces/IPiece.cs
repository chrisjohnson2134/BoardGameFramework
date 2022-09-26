using Game.Framework.MoveGenerators.Moves;
using System.Collections.Generic;

namespace Game.Framework.Models.Pieces
{
    public interface IPiece
    {
        public List<IPieceMove> PieceMoves { get; set; }
    }
}