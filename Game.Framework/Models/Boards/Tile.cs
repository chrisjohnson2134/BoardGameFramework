using Game.Framework.Models.Pieces;

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
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public IPiece TilePiece {get;set;}
        public string HighlightColor { get; set; }
        public bool Highlight { get; set; }

    }
}
