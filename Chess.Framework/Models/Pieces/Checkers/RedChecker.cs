using Chess.Framework.Constants;
using Game.Framework.Enums;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.MoveGenerators.Moves.CheckersMoves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces.Checkers
{
    public class RedChecker : CheckersPiece
    {
        public RedChecker(CheckersBoard checkersBoard)
            : base(checkersBoard)
        {
            PieceMoves.Add(new StandardCheckersMove(Directions.Down,_checkersBoard));
            PieceMoves.Add(new JumpMove(Directions.Down,_checkersBoard));

            Label = Constants.Red;
        }

        public override string Color => Constants.Red;

        public override CheckersPiece King()
        {
            PieceMoves.Add(new StandardCheckersMove(Directions.Up, _checkersBoard));
            PieceMoves.Add(new JumpMove(Directions.Up, _checkersBoard));

            Label = Constants.Red.ToUpper();

            return this;
        }

    }
}
