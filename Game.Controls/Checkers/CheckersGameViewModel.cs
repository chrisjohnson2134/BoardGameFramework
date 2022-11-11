using Chess.Framework.Constants;
using Game.Controls.Board;
using Game.Controls.WpfHelpers;
using Game.Framework.Models.Boards;
using Game.Framework.Models.Checkers;
using Game.Framework.Models.Pieces.Checkers;
using Game.Framework.MoveGenerators;
using Game.Framework.MoveGenerators.Checkers;
using Game.Framework.MoveGenerators.Moves.CheckersMoves;
using Game.Framework.SetupFactories.Checkers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Game.Controls.Checkers
{
    public class CheckersGameViewModel : SimplisticBase
    {
        private IMoveGenerator _moveGenerator;
        private CheckersBoard _board;

        private TileViewModel _fromTile;
        private TileViewModel _toTile;

        public CheckersGameViewModel()
        {
            TilePieces = new ObservableCollection<TileViewModel>();

            _board = new CheckersBoardFactory().GenerateBoard();
            _moveGenerator = new CheckersMoveGenerator(_board);

            PlayersTurn = Constants.Black;

            MustTakeJump = true;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
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
            if (_fromTile != null && _toTile == null)
            {
                _toTile = TilePieces.FirstOrDefault(t => t.Id == e.Id);
                _toTile.Highlight = true;
                _toTile.HighlightColor = Constants.Red;
            }

            if (_fromTile == null)
            {
                _fromTile = TilePieces.FirstOrDefault(t => t.Id == e.Id);
                if (PlayersTurn == Constants.Red && !(_fromTile.TilePiece is RedChecker)
                    || PlayersTurn == Constants.Black && !(_fromTile.TilePiece is BlackChecker))
                {
                    _fromTile = null;
                    return;
                }

                _fromTile.Highlight = true;
                _fromTile.HighlightColor = Constants.Yellow;
            }

            if (_toTile != null)
            {
                var movesList = _moveGenerator.GenerateAllMoves();
                bool containsJump = MustTakeJump ? playerMustJump(movesList) : false;

                foreach (var item in movesList)
                {
                    if (item is ValidBasicMove mv && !containsJump)
                    {
                        if (_board.GetTile(mv.ToRow, mv.ToCol).Id == _toTile.Id && _board.GetTile(mv.FromRow, mv.FromCol).Id == _fromTile.Id)
                        {
                            _toTile.TilePiece = _fromTile.TilePiece;
                            _fromTile.TilePiece = new EmptyChecker(_board);
                            if (mv.King)
                            {
                                (_toTile.TilePiece as ICheckerPiece).King();
                                _toTile.RefreshTile();
                            }

                            swapPlayer();
                        }
                    }
                    else if (item is ValidJumpMove jump)
                    {
                        if (_board.GetTile(jump.ToRow, jump.ToCol).Id == _toTile.Id && _board.GetTile(jump.FromRow, jump.FromCol).Id == _fromTile.Id)
                        {
                            _toTile.TilePiece = _fromTile.TilePiece;
                            _fromTile.TilePiece = new EmptyChecker(_board);
                            var takeTile = _board.GetTile(jump.TakeRow, jump.TakeCol);
                            var takeTileVM = TilePieces.FirstOrDefault(t => t.Id == takeTile.Id);
                            takeTileVM.TilePiece = new EmptyChecker(_board);
                            if (jump.King)
                            {
                                (_toTile.TilePiece as ICheckerPiece).King();
                                _toTile.RefreshTile();
                            }
                            if (!playerMustJump(_moveGenerator.GenerateAllMoves()))
                                swapPlayer();
                        }
                    }
                }

                _fromTile.Highlight = false;
                _toTile.Highlight = false;

                _fromTile = null;
                _toTile = null;
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

        public bool MustTakeJump
        {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }

        private bool playerMustJump(List<IValidMove> movesList)
        {
            if (PlayersTurn == Constants.Red)
                return movesList.Any(t => t is ValidJumpMove jmp && _board.GetPiece(jmp.FromRow, jmp.FromCol) is RedChecker);
            else
                return movesList.Any(t => t is ValidJumpMove jmp && _board.GetPiece(jmp.FromRow, jmp.FromCol) is BlackChecker);
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
