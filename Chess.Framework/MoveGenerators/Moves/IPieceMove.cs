using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves
{
    public interface IPieceMove
    {
        List<IValidMove> GeneratePieceMoves(int row, int col);

    }
}
