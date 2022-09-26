using Game.Framework.Models.Pieces;

namespace Game.Framework.Models.Boards
{
    public interface ITile
    {
        int Id { get; set; }
        string HighlightColor { get; set; }
        bool Highlight { get; set; }
        string BackgroundColor { get; set; }
        IPiece TilePiece { get; set; }
    }
}
