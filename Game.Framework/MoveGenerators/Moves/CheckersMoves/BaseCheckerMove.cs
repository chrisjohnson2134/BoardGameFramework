using Game.Framework.Enums;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.CheckersMoves
{
    public abstract class BaseCheckerMove
    {
        public Directions MoveDirections { get; set; }
        public CheckersBoard Board { get; set; }

        protected bool moveInbounds(int row, int col)
        {
            return row >= 0 && col >= 0 && col < 8 && row < 8;
        }

        protected bool isEmptySpot(int row, int col)
        {
            if (Board.GetPiece(row, col) is EmptyChecker)
                return true;

            return false;
        }

        protected bool isOpenentPiece(int myRow, int myCol, int opRow, int opCol)
        {
            if (Board.GetPiece(opRow, opCol) is EmptyChecker)
                return false;

            if (Board.GetPiece(opRow, opCol) is RedChecker
                && Board.GetPiece(myRow, myCol) is BlackChecker)
            {
                return true;
            }
            else if (Board.GetPiece(opRow, opCol) is BlackChecker
                && Board.GetPiece(myRow, myCol) is RedChecker)
            {
                return true;
            }

            return false;
        }

        protected bool willBeKinged(bool isRed,int row)
        {
            if (isRed)
                return row == 0;

            return row == 7;
        }
    }
}
