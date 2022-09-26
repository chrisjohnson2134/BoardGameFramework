using Game.Framework.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Boards
{
    public class SquareBoard
    {

        private readonly int _rows;
        private readonly int _columns;

        public SquareBoard(int columns,int rows)
        {
            _columns = columns;
            _rows = rows;

            Tiles = new ITile[columns, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Tiles[row, col] = new Tile();
                }
            }
        }

        public ITile[,] Tiles { get; set; }

        public int Rows => _rows;
        public int Cols => _columns;

        public IPiece GetPiece(int row,int col)
        {
            var piece = Tiles[row,col].TilePiece;
            return piece;
        }

        public ITile GetTile(int row,int col)
        {
            return Tiles[row,col];
        }

    }
}
