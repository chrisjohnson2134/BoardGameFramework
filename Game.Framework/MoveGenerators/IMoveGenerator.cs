using Game.Framework.Models.Pieces;
using Game.Framework.MoveGenerators.Checkers;
using System;
using System.Collections.Generic;

namespace Game.Framework.MoveGenerators
{
    public interface IMoveGenerator
    {
        List<IValidMove> GenerateAllMoves();

        List<IValidMove> GeneratePieceMoves(IPiece piece);
    }
}