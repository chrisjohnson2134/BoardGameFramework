using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Test.Models.Boards
{
    public class TicTacToeBoardTest
    {
        //A Tic Tac Toe board should be 3 x 3 and empty
        [Test]
        public void TicTacToeBoardSetupCorrectly()
        {
            var board = new TicTacToeBoard();
            foreach (var item in board.Tiles)
            {
                Assert.IsTrue(item.TilePiece is EmptyPiece);
            }
            Assert.AreEqual(3,board.Cols);
            Assert.AreEqual(3,board.Rows);
        }
    }
}
