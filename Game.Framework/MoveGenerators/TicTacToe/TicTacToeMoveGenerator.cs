using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces;
using Game.Framework.MoveGenerators.Checkers;
using Game.Framework.MoveGenerators.Moves.TicTacToeMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.TicTacToe
{
    public class TicTacToeMoveGenerator : ITicTacToeMoveGenerator
    {
        TicTacToeBoard _ticTacToeBoard;

        public TicTacToeMoveGenerator(TicTacToeBoard ticTacToeBoard)
        {
            _ticTacToeBoard = ticTacToeBoard;
        }

        public List<IValidMove> GenerateAllMoves()
        {
            var outputValidMoves = new List<IValidMove>();
            for (int i = 0; i < _ticTacToeBoard.Rows; i++)
            {
                for (int j = 0; j < _ticTacToeBoard.Cols; j++)
                {
                    if (_ticTacToeBoard.Tiles[i, j].TilePiece is EmptyPiece)
                        outputValidMoves.Add(new PlaceMove(i, j));
                }
            }
            return outputValidMoves;
        }

        //Return negative -1 -1 to show that the space is empty?
        public List<IValidMove> GeneratePieceMoves(IPiece piece)
        {
            var outputMoves = new List<IValidMove>();
            if(piece is EmptyPiece)
                outputMoves.Add( new PlaceMove(-1, -1) );

            return outputMoves;
        }
    }
}
