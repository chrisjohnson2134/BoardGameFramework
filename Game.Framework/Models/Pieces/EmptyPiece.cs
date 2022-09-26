using Game.Framework.MoveGenerators.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces
{
    public class EmptyPiece : IPiece
    {
        public EmptyPiece()
        {
            PieceMoves = new List<IPieceMove>();
        }

        public List<IPieceMove> PieceMoves { get; set; }
    }
}
