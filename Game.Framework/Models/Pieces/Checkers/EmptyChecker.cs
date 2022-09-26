using Chess.Framework.Constants;
using Game.Framework.Models.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces.Checkers
{
    public class EmptyChecker : CheckersPiece
    {
        public EmptyChecker(CheckersBoard checkersBoard) 
            : base(checkersBoard)
        {
            Color = String.Empty;
        }
    }
}
