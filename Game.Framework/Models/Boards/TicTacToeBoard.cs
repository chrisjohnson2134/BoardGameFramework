using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Boards
{
    public class TicTacToeBoard : SquareBoard
    {
        public TicTacToeBoard() 
            : base(3, 3)
        {
        }
    }
}
