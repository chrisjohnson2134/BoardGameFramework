using Chess.Framework.Constants;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces;
using Game.Framework.Models.Pieces.Checkers;

namespace Game.Framework.SetupFactories.Checkers
{
    public class CheckersBoardFactory
    {
        public CheckersBoard GenerateBoard()
        {
            CheckersBoard board = new CheckersBoard();

            for(int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (row < 3)
                    {
                        if (row % 2 == 0)
                        {
                            if (col % 2 == 1)
                                board.Tiles[row, col].TilePiece = new BlackChecker(board);
                        }
                        else
                        {
                            if (col % 2 != 1)
                                board.Tiles[row, col].TilePiece = new BlackChecker(board);
                        }
                    }
                    else if (row > 4)
                    {
                        if (row % 2 != 0)
                        {
                            if (col % 2 != 1)
                                board.Tiles[row, col].TilePiece = new RedChecker(board);
                        }
                        else
                        {
                            if (col % 2 == 1)
                                board.Tiles[row, col].TilePiece = new RedChecker(board);
                        }
                    }

                }
            }

            return board;
        }

    }
}
