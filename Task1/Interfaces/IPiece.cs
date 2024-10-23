using Task1.Entities.ChessPieces;

namespace Task1.Interfaces;

public interface IPiece
{
    (int X, int Y) Position { get; }
    List<(int X, int Y)> GetPossibleMoves(ChessBoard board);
    bool IsMoveSafe(ChessBoard board, (int X, int Y) move);
}
