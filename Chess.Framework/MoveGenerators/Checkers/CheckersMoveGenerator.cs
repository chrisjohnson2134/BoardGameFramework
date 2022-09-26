using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.MoveGenerators.Moves;
using Game.Framework.MoveGenerators.Moves.CheckersMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Checkers
{
    public class CheckersMoveGenerator : ICheckersMoveGenerator
    {
        private CheckersBoard _squareBoard;

        public CheckersMoveGenerator(CheckersBoard squareBoard)
        {
            _squareBoard = squareBoard;
        }

        public List<IValidMove> GenerateAllMoves()
        {
            return GenerateMoves(String.Empty);
        }

        public List<IValidMove> GeneratePieceMoves(IPiece piece)
        {
            return GenerateMoves(String.Empty);
        }

        private List<IValidMove> GenerateMoves(string pieceColor)
        {
            List<IValidMove> moves = new List<IValidMove>();

            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++)
                {
                    foreach (var move in _squareBoard.GetPiece(row, col).PieceMoves)
                    {
                        moves.AddRange(move.GeneratePieceMoves(row,col));
                    }
                }
            }

            return moves;
        }

    }
}
