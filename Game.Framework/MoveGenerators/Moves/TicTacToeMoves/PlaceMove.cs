using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.MoveGenerators.Moves.TicTacToeMoves
{
    public class PlaceMove : IValidMove
    {
        public PlaceMove(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }  
    }
}
