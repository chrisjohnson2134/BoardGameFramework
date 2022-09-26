using Chess.Framework.Constants;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.Models.Pieces;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.SetupFactories.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Test.SetupFactories
{
    public class CheckersBoardFactoryTest
    {
        CheckersBoardFactory factory = new CheckersBoardFactory();

        [Test]
        public void SetupACorrectCheckersBoard()
        {
            SquareBoard board = factory.GenerateBoard();

            //Pieces Check
            //BLACK
            Assert.IsTrue(board.GetPiece(0, 0) is EmptyChecker);
            Assert.IsTrue(board.GetPiece(0, 1) is BlackChecker);

            Assert.IsTrue(board.GetPiece(1, 0) is BlackChecker);
            Assert.IsTrue(board.GetPiece(1, 1) is EmptyChecker);

            Assert.IsTrue(board.GetPiece(2, 0) is EmptyChecker);
            Assert.IsTrue(board.GetPiece(2, 1) is BlackChecker);

            //MIDDLE
            Assert.IsTrue(board.GetPiece(3, 0) is EmptyChecker);
            Assert.IsTrue(board.GetPiece(3, 1) is EmptyChecker);

            Assert.IsTrue(board.GetPiece(4, 0) is EmptyChecker);
            Assert.IsTrue(board.GetPiece(4, 1) is EmptyChecker);

            //RED
            Assert.IsTrue(board.GetPiece(5, 0) is RedChecker);
            Assert.IsTrue(board.GetPiece(5, 1) is EmptyChecker);

            Assert.IsTrue(board.GetPiece(6, 0) is EmptyChecker);
            Assert.IsTrue(board.GetPiece(6, 1) is RedChecker);

            Assert.IsTrue(board.GetPiece(7, 0) is RedChecker);
            Assert.IsTrue(board.GetPiece(7, 1) is EmptyChecker);


            //Board Check
            Assert.AreEqual(Constants.White,board.GetTile(0, 0).BackgroundColor);
            Assert.AreEqual(Constants.Black,board.GetTile(0, 1).BackgroundColor);

            Assert.AreEqual(Constants.Black, board.GetTile(1, 0).BackgroundColor);
            Assert.AreEqual(Constants.White,board.GetTile(1, 1).BackgroundColor);

            Assert.AreEqual(Constants.Black, board.GetTile(7, 0).BackgroundColor);
            Assert.AreEqual(Constants.White, board.GetTile(7, 1).BackgroundColor);
        }
    }
}
