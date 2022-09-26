using Game.Controls.WpfHelpers;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.Models.Pieces;
using Game.Framework.MoveGenerators.Checkers;
using Game.Framework.MoveGenerators.Moves.CheckersMoves;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Controls.Board
{
    public class TileViewModel : SimplisticBase
    {
        public event EventHandler<ITile> TileClicked;


        public TileViewModel(ITile tile)
        {
            TileModel = tile;
            TileClickedCommand = new RelayCommand(TileClickedCommandHandler);
        }

        public ICommand TileClickedCommand
        {
            get => GetPropertyValue<ICommand>();
            set => SetPropertyValue(value);
        }

        public ITile TileModel
        {
            get => GetPropertyValue<ITile>();
            set => SetPropertyValue(value);
        }

        public string BackgroundColor
        {
            get => TileModel.BackgroundColor;
            set
            {
                TileModel.BackgroundColor = value;
                SetPropertyValue(value);
            }
        }

        public bool Highlight
        {
            get => TileModel.Highlight;
            set
            {
                TileModel.Highlight = value;
                SetPropertyValue(value);
            }
        }

        public string HighlightColor
        {
            get => TileModel.HighlightColor;
            set
            {
                TileModel.HighlightColor = value;
                SetPropertyValue(value);
            }
        }

        public IPiece TilePiece
        {
            get => TileModel.TilePiece;
            set
            {
                TileModel.TilePiece = value;
                SetPropertyValue(value);
            }
        }

        public int Id => TileModel.Id;


        private void TileClickedCommandHandler(object obj)
        {
            TileClicked?.Invoke(this, TileModel);
        }

        public void RefreshTile()
        {
            RaisePropertyChanged(nameof(TilePiece));
        }
    }
}
