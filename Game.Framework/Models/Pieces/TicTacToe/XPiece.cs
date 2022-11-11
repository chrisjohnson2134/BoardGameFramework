using Game.Framework.MoveGenerators.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces.TicTacToe
{
    public class XPiece : IPiece
    {
        public List<IPieceMove> PieceMoves { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
