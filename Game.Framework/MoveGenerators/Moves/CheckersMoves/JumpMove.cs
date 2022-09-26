using Game.Framework.Enums;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.CheckersMoves
{
    public class JumpMove : BaseCheckerMove, IPieceMove
    {

        public JumpMove(Directions moveDirections, CheckersBoard board)
        {
            MoveDirections = moveDirections;
            Board = board;
        }

        public List<IValidMove> GeneratePieceMoves(int row, int col)
        {
            int toRow, toCol,jumpRow, jumpCol;
            bool king;
            List<IValidMove> moves = new List<IValidMove>();


            if (MoveDirections == Enums.Directions.Up)
            {
                toRow = row + 2;
                jumpRow = row + 1;
            }
            else
            {
                toRow = row - 2;
                jumpRow= row - 1;
            }

            king = willBeKinged(Board.GetPiece(row,col) is RedChecker, toRow);

            //Right
            toCol = col + 2;
            jumpCol = col + 1;
            if (moveInbounds(toRow, toCol))
            {
                if (isEmptySpot(toRow, toCol) && isOpenentPiece(row, col, jumpRow, jumpCol))
                {
                    moves.Add(new ValidJumpMove(row, col, toRow, toCol, jumpRow, jumpCol,king));
                }
            }

            //Left
            toCol = col - 2;
            jumpCol = col - 1;
            if (moveInbounds(toRow, toCol))
            {
                if (isEmptySpot(toRow,toCol) && isOpenentPiece(row,col,jumpRow,jumpCol))
                {
                    moves.Add(new ValidJumpMove(row, col, toRow, toCol, jumpRow, jumpCol,king));
                }
            }

            return moves;
        }
    }
}
