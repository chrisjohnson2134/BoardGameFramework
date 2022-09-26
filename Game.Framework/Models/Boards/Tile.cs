using Chess.Framework.Constants;
using Game.Framework.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Framework.Models.Boards
{
    public class Tile : ITile
    {
        public Tile()
        {
            TilePiece = new EmptyPiece();
            HighlightColor = "Transparent";
        }

        public int Id { get; set; }
        public string BackgroundColor { get; set; }
        public IPiece TilePiece {get;set;}
        public string HighlightColor { get; set; }
        public bool Highlight { get; set; }

    }
}
