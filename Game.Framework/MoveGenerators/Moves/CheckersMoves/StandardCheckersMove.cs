using Game.Framework.Enums;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.Models.Pieces;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.CheckersMoves
{
    public class StandardCheckersMove : BaseCheckerMove, IPieceMove
    {
        public StandardCheckersMove(Directions moveDirections, CheckersBoard piece)
        {
            MoveDirections = moveDirections;
            Board = piece;
        }

        public List<IValidMove> GeneratePieceMoves(int row, int col)
        {
            int toRow, toCol;
            bool king;

            List<IValidMove> moves = new List<IValidMove>();

            if (MoveDirections == Enums.Directions.Up)
                toRow = row + 1;
            else
                toRow = row - 1;

            king = willBeKinged(Board.GetPiece(row, col) is RedChecker, toRow);

            //Right
            toCol = col + 1;
            if (moveInbounds(toRow, toCol))
            {
                if (isEmptySpot(toRow,toCol))
                {
                    moves.Add(new ValidBasicMove(row, col, toRow, toCol, king));
                }
            }

            //Left
            toCol = col - 1;
            if (moveInbounds(toRow, toCol))
            {
                if (isEmptySpot(toRow, toCol))
                {
                    moves.Add(new ValidBasicMove(row, col, toRow, toCol, king));
                }
            }

            return moves;
        }
    }
}
