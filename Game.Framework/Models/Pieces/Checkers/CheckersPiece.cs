using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.MoveGenerators.Moves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Pieces.Checkers
{
    public class CheckersPiece : ICheckerPiece
    {
        protected CheckersBoard _checkersBoard;

        public CheckersPiece(CheckersBoard checkersBoard)
        {
            _checkersBoard = checkersBoard;
            PieceMoves = new List<IPieceMove>();
        }

        public string Label { get; set; }

        public virtual string Color { get; set; }

        public bool IsKing { get; set; }
        public List<IPieceMove> PieceMoves { get; set; }

        public virtual ICheckerPiece King()
        {
            Label = Label.ToUpper();
            return this;
        }
    }
}
