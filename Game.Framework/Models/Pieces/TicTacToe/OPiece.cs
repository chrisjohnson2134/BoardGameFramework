using Game.Framework.MoveGenerators.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces.TicTacToe
{
    public class OPiece : IPiece
    {
        public List<IPieceMove> PieceMoves { get; set; }
        public string Label => "O";

    }
}
