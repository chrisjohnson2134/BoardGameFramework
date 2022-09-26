using Chess.Framework.Constants;
using Game.Framework.Models.Pieces.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Boards
{
    public class CheckersBoard : SquareBoard
    {
        public CheckersBoard() :
            base(8,8)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Tiles[row, col].TilePiece = new EmptyChecker(this);

                    //Set Tile Colors
                    if (row % 2 == 0)
                    {
                        if (col % 2 != 0)
                            Tiles[row, col].BackgroundColor = Constants.Black;
                        else
                            Tiles[row, col].BackgroundColor = Constants.White;
                    }
                    else
                    {
                        if (col % 2 != 0)
                            Tiles[row, col].BackgroundColor = Constants.White;
                        else
                            Tiles[row, col].BackgroundColor = Constants.Black;
                    }

                    Tiles[row, col].Id = (row * 8) + col;

                }
            }
        }
    }
}
