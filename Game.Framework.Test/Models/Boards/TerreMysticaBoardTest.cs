using Game.Framework.Models.Boards;
using Game.Framework.Models.Boards.TerreMystica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Test.Models.Boards
{
    [TestFixture]
    public class TerreMysticaBoardTest
    {
        [Test]
        public void BoardShouldGetPaternedApropriately() 
        {
            var board = new TerreMysticaBoard();

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    Console.Write((board.Tiles[i, j] as Tile).Name );
                }
                Console.WriteLine();
            }
        }
    }
}
