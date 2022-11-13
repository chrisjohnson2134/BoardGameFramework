using Chess.Framework.Constants;
using Game.Framework.Models.Pieces.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Boards.TerreMystica
{
    public class TerreMysticaBoard : SquareBoard
    {

        public TerreMysticaBoard() 
            : base(Constants.TERRE_COLS, Constants.TERRE_ROWS)
        {
            int indentCount = 0;
            bool indentRight = true;
            for (int row = 0; row < Constants.TERRE_ROWS; row++)
            {
                for (int col = 0; col < Constants.TERRE_COLS; col++)
                {
                    Tiles[row, col] = new EmptyTile();
                }

                //Wow, I'm sorry...
                //row 0
                Tiles[0, 0] = new FarmTile();
                Tiles[0, 2] = new RockTile();
                Tiles[0, 4] = new ForestTile();
                Tiles[0, 6] = new WetlandTile();
                Tiles[0, 8] = new SandTile();
                Tiles[0, 10] = new BadlandsTile();
                Tiles[0, 12] = new FarmTile();
                Tiles[0, 14] = new WasteTile();
                Tiles[0, 16] = new BadlandsTile();
                Tiles[0, 18] = new ForestTile();
                Tiles[0, 20] = new WetlandTile();
                Tiles[0, 22] = new BadlandsTile();
                Tiles[0, 24] = new WasteTile();

                //row 1
                Tiles[1, 1] = new SandTile();
                Tiles[1, 3] = new WaterTile();
                Tiles[1, 5] = new WaterTile();
                Tiles[1, 7] = new FarmTile();
                Tiles[1, 9] = new WasteTile();
                Tiles[1, 11] = new WaterTile();
                Tiles[1, 13] = new WaterTile();
                Tiles[1, 15] = new SandTile();
                Tiles[1, 17] = new WasteTile();
                Tiles[1, 19] = new WaterTile();
                Tiles[1, 21] = new WaterTile();
                Tiles[1, 23] = new SandTile();

                //row 2
                Tiles[2, 2] = new WaterTile();
                Tiles[2, 4] = new WasteTile();
                Tiles[2, 6] = new WaterTile();
                Tiles[2, 8] = new RockTile();
                Tiles[2, 10] = new WaterTile();
                Tiles[2, 12] = new ForestTile();
                Tiles[2, 14] = new WaterTile();
                Tiles[2, 16] = new ForestTile();
                Tiles[2, 18] = new WaterTile();
                Tiles[2, 20] = new RockTile();
                Tiles[2, 22] = new WaterTile();

                //row 3
                Tiles[3, 1] = new ForestTile();
                Tiles[3, 3] = new WetlandTile();
                Tiles[3, 5] = new SandTile();
                Tiles[3, 7] = new WaterTile();
                Tiles[3, 9] = new WaterTile();
                Tiles[3, 11] = new BadlandsTile();
                Tiles[3, 13] = new WetlandTile();
                Tiles[3, 15] = new WaterTile();
                Tiles[3, 17] = new BadlandsTile();
                Tiles[3, 19] = new WaterTile();
                Tiles[3, 21] = new BadlandsTile();
                Tiles[3, 23] = new FarmTile();
            }
        }
    }
}
