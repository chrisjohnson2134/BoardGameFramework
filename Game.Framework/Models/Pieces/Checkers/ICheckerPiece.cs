using Game.Framework.Models.Pieces;
using Game.Framework.Models.Pieces.Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Checkers
{
    public interface ICheckerPiece : IPiece
    {
        public string Color { get; }
        public bool IsKing { get; set; }

        public ICheckerPiece King();
    }
}
