using Game.Framework.Models.Pieces;
using Game.Framework.MoveGenerators.Moves;
using System;
using System.Collections.Generic;

namespace Game.Framework.MoveGenerators.Checkers
{
    public interface IMoveGenerator
    {
        List<IValidMove> GenerateAllMoves();

        List<IValidMove> GeneratePieceMoves(IPiece piece);
    }
}