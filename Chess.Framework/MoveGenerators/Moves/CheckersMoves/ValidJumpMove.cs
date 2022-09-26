using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.CheckersMoves
{
    public class ValidJumpMove : IValidMove
    {
        public ValidJumpMove(int fromRow,int fromCol, int toRow, int toCol, int takeRow, int takeCol, bool king)
        {
            FromRow = fromRow;
            FromCol = fromCol;
            ToRow = toRow;
            ToCol = toCol;
            TakeRow = takeRow;
            TakeCol = takeCol;
            King = king;
        }

        public int FromRow { get; set; }
        public int FromCol { get; set; }

        public int ToRow { get; set; }
        public int ToCol { get; set; }

        public int TakeRow { get; set; }
        public int TakeCol { get; set; }

        public bool King { get; set; }
    }
}
