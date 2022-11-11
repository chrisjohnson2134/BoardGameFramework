using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces.TicTacToe;
using Game.Framework.MoveGenerators.Moves.TicTacToeMoves;
using Game.Framework.MoveGenerators.TicTacToe;

namespace Game.Framework.Test.MoveGenerators.TicTacToe
{
    [TestFixture]
    public class TicTacToeMoveGeneratorTest
    {
        TicTacToeBoard _ticTacToeBoard;
        TicTacToeMoveGenerator _ticTacToeMoveGenerator;


        [SetUp]
        public void Initialize()
        {
            _ticTacToeBoard = new TicTacToeBoard();
            _ticTacToeMoveGenerator = new TicTacToeMoveGenerator(_ticTacToeBoard);
        }

        //empty board should return all spaces on the board as valid
        [Test]
        public void AllSpacesShouldBeValidOnStartup()
        {
            var validMoves = _ticTacToeMoveGenerator.GenerateAllMoves().Cast<PlaceMove>().ToList();

            for (int i = 0; i < _ticTacToeBoard.Rows; i++)
            {
                for (int j = 0; j < _ticTacToeBoard.Cols; j++)
                {
                    Assert.IsTrue(validMoves.Any(t => t.X == i && t.Y == j));
                }
            }
        }

        //board with two pieces returns correctly
        [Test]
        public void PiecesPlaced()
        {
            _ticTacToeBoard.Tiles[0,0].TilePiece = new XPiece();
            _ticTacToeBoard.Tiles[2,2].TilePiece = new OPiece();

            var validMoves = _ticTacToeMoveGenerator.GenerateAllMoves().Cast<PlaceMove>().ToList();

            for (int i = 0; i < _ticTacToeBoard.Rows; i++)
            {
                for (int j = 0; j < _ticTacToeBoard.Cols; j++)
                {
                    if(i == 0 && j == 0)
                        Assert.IsFalse(validMoves.Any(t => t.X == i && t.Y == j));
                    else if(i == 2 && j == 2)
                        Assert.IsFalse(validMoves.Any(t => t.Y == i && t.X == j));
                    else
                        Assert.IsTrue(validMoves.Any(t => t.X == i && t.Y == j));
                }
            }
        }
    }
}
