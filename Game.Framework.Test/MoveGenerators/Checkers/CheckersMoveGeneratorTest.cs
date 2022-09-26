using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.MoveGenerators.Checkers;
using Game.Framework.MoveGenerators.Moves.CheckersMoves;
using Game.Framework.SetupFactories.Checkers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Test.MoveGenerators.Checkers
{
    public class CheckersMoveGeneratorTest
    {
        private CheckersBoardFactory _checkersBoardFactory;

        [SetUp]
        public void SetupTest()
        {
            _checkersBoardFactory = new CheckersBoardFactory();
        }

        [Test]
        public void GenerateBasicCheckersMoves()
        {
            var board = _checkersBoardFactory.GenerateBoard();

            var checkersMoveGenerator = new CheckersMoveGenerator(board);

            var moves = checkersMoveGenerator.GenerateAllMoves();

            if(moves.Any(t => t is ValidJumpMove))
            {
                Assert.Fail();
            }

            foreach (var move in checkersMoveGenerator.GenerateAllMoves())
            {
                if (move is ValidBasicMove vmove)
                    if(board.GetTile(vmove.ToRow, vmove.ToCol).HighlightColor == "Green")
                        board.GetTile(vmove.ToRow, vmove.ToCol).HighlightColor = "Red";
                    else
                        board.GetTile(vmove.ToRow, vmove.ToCol).HighlightColor = "Green";
            }

            for (int i = 0; i < 8; i++)
            {
                if(i % 2 == 0 && i == 0)
                    Assert.That("Green" == board.GetTile(3, i).HighlightColor);
                else if(i % 2 == 0)
                    Assert.That("Red" == board.GetTile(3, i).HighlightColor);


                if (i % 2 != 0 && i == 7)
                    Assert.That("Green" == board.GetTile(4, i).HighlightColor );
                else if(i % 2 != 0)
                    Assert.That("Red" == board.GetTile(4, i).HighlightColor);
            }

        }

        [Test]
        public void ComputesBasicJumps()
        {
            var board = new CheckersBoard();

            board.Tiles[3,2].TilePiece = new BlackChecker(board);

            board.Tiles[4,1].TilePiece = new RedChecker(board);
            board.Tiles[4,3].TilePiece = new RedChecker(board);

            var checkersMoveGenerator = new CheckersMoveGenerator(board);

            var moves = checkersMoveGenerator.GenerateAllMoves();

            foreach (var move in moves)
            {
                if(move is ValidJumpMove jump)
                {
                    if (jump.FromCol == 2 && jump.FromRow == 3)
                    {
                        board.Tiles[jump.FromRow, jump.FromCol].TilePiece = new EmptyChecker(board);
                        board.Tiles[jump.TakeRow, jump.TakeCol].TilePiece = new EmptyChecker(board);
                        board.Tiles[jump.ToRow, jump.ToCol].TilePiece = new BlackChecker(board);
                    }
                }
            }

            Assert.IsTrue(board.Tiles[3, 2].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[4, 1].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[4, 3].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[5, 0].TilePiece is BlackChecker);
            Assert.IsTrue(board.Tiles[5, 4].TilePiece is BlackChecker);

        }

        [Test]
        public void ComputesInvalidWithBlockingPiecesJumps()
        {
            var board = new CheckersBoard();

            board.Tiles[3, 2].TilePiece = new BlackChecker(board);

            board.Tiles[4, 1].TilePiece = new RedChecker(board);
            board.Tiles[4, 3].TilePiece = new RedChecker(board);
            board.Tiles[5, 0].TilePiece = new RedChecker(board);
            board.Tiles[5, 4].TilePiece = new RedChecker(board);

            var checkersMoveGenerator = new CheckersMoveGenerator(board);

            var moves = checkersMoveGenerator.GenerateAllMoves();

            foreach (var move in moves)
            {
                if (move is ValidJumpMove jump)
                {
                    if(jump.FromCol == 2 && jump.FromRow == 3)
                    {
                        board.Tiles[jump.FromRow, jump.FromCol].TilePiece = new EmptyChecker(board);
                        board.Tiles[jump.TakeRow, jump.TakeCol].TilePiece = new EmptyChecker(board);
                        board.Tiles[jump.ToRow, jump.ToCol].TilePiece = new BlackChecker(board);
                    }
                    
                }
            }

            Assert.IsTrue(board.Tiles[3, 2].TilePiece is BlackChecker);
            Assert.IsTrue(board.Tiles[4, 1].TilePiece is RedChecker);
            Assert.IsTrue(board.Tiles[4, 3].TilePiece is RedChecker);
            Assert.IsTrue(board.Tiles[5, 0].TilePiece is RedChecker);
            Assert.IsTrue(board.Tiles[5, 4].TilePiece is RedChecker);

        }

        [Test]
        public void TestKingMoveJumpPieces()
        {
            var board = new CheckersBoard();

            CheckersPiece checkersPiece = new BlackChecker(board);

            board.Tiles[4, 4].TilePiece = checkersPiece.King();

            board.Tiles[5, 5].TilePiece = new RedChecker(board);
            board.Tiles[5, 3].TilePiece = new RedChecker(board);
            board.Tiles[3, 5].TilePiece = new RedChecker(board);
            board.Tiles[3, 3].TilePiece = new RedChecker(board);

            generateAndApplyMoves(board);

            Assert.IsTrue(board.Tiles[5, 5].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[5, 3].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[3, 5].TilePiece is EmptyChecker);
            Assert.IsTrue(board.Tiles[3, 3].TilePiece is EmptyChecker);
        }

        private void generateAndApplyMoves(CheckersBoard board)
        {
            var checkersMoveGenerator = new CheckersMoveGenerator(board);

            var moves = checkersMoveGenerator.GenerateAllMoves();

            foreach (var move in moves)
            {
                if (move is ValidJumpMove jump)
                {
                    board.Tiles[jump.FromRow, jump.FromCol].TilePiece = new EmptyChecker(board);
                    board.Tiles[jump.TakeRow, jump.TakeCol].TilePiece = new EmptyChecker(board);
                    board.Tiles[jump.ToRow, jump.ToCol].TilePiece = new BlackChecker(board);
                }
                else if( move is ValidBasicMove mv)
                {
                    board.Tiles[mv.FromRow, mv.FromCol].TilePiece = new EmptyChecker(board);
                    board.Tiles[mv.ToRow, mv.ToCol].TilePiece = new BlackChecker(board);
                }
            }
        }

    }
}
