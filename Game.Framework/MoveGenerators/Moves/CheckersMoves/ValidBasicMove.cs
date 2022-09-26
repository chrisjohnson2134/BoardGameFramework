using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.CheckersMoves
{
    public  class ValidBasicMove : IValidMove
    {

        public ValidBasicMove(int toCol,int toRow)
        {
            ToCol = toCol;
            ToRow = toRow;
        }

        public ValidBasicMove(int fromRow, int fromCol, int toRow, int toCol, bool king)
        {
            FromCol = fromCol;
            FromRow = fromRow;

            ToCol = toCol;
            ToRow = toRow;

            King = king;
        }

        public int ToCol { get; set; }
        public int ToRow { get; set; }

        public int FromCol { get; set; }
        public int FromRow { get; set; }

        public bool King { get; set; }
    }
}
