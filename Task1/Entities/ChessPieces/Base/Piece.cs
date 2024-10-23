using Task1.Interfaces;

namespace Task1.Entities.ChessPieces.Base;

public abstract class Piece : IPiece
{
    public (int X, int Y) Position { get; protected set; }

    public abstract List<(int X, int Y)> GetPossibleMoves(ChessBoard board);

    public abstract bool IsMoveSafe(ChessBoard board, (int X, int Y) move);
}
