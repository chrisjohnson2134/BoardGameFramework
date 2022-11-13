using Game.Framework.Models.Pieces;

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

            Tiles = new ITile[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Tiles[row, col] = new Tile();
                    Tiles[row, col].Id = (row * columns) + col;
                }
            }
        }

        /// <summary>
        /// Follows Row,Column positioning
        /// </summary>
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
