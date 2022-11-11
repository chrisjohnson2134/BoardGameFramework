using Chess.Framework.Constants;
using Game.Controls.Board;
using Game.Controls.WpfHelpers;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Pieces.TicTacToe;
using Game.Framework.MoveGenerators;
using Game.Framework.MoveGenerators.Moves.TicTacToeMoves;
using Game.Framework.MoveGenerators.TicTacToe;
using System.Collections.ObjectModel;
using System.Linq;

namespace Game
{
    public class MainWindowViewModel : SimplisticBase
    {
        private IMoveGenerator _moveGenerator;
        private TicTacToeBoard _board;
        public MainWindowViewModel()
        {
            TilePieces = new ObservableCollection<TileViewModel>();

            _board = new TicTacToeBoard();
            _moveGenerator = new TicTacToeMoveGenerator(_board);

            PlayersTurn = Constants.Black;

            for (int row = 0; row < 3; row++)
            {
                for(int col = 0; col < 3; col++)
                {
                    var tileVM = new TileViewModel(_board.GetTile(row, col));
                    tileVM.TileClicked += TileVM_TileClicked;
                    TilePieces.Add(tileVM);
                }
            }

        }

        //This will likely be abstracted to a human.
        //A human will know how to play the game.
        private void TileVM_TileClicked(object? sender, ITile e)
        {
            var validMove = _moveGenerator.GeneratePieceMoves(e.TilePiece).Any(t => t is PlaceMove);
            var tile = TilePieces.FirstOrDefault(t => t.Id == e.Id);

            if (validMove)
            {
                if(PlayersTurn== Constants.Black) 
                {
                    tile.TilePiece = new XPiece();
                }
                else
                {
                    tile.TilePiece = new OPiece();
                }
                swapPlayer();
            }
        }

        public ObservableCollection<TileViewModel> TilePieces
        {
            get => GetPropertyValue<ObservableCollection<TileViewModel>>();
            set => SetPropertyValue(value);
        }

        public string PlayersTurn
        {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        private void swapPlayer()
        {
            if (PlayersTurn == Constants.Red)
            {
                PlayersTurn = Constants.Black;
            }
            else
            {
                PlayersTurn = Constants.Red;
            }
        }
    }
}
