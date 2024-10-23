using Task1.Interfaces;

namespace Task1.Entities.ChessPieces;

public class ChessBoard
{
    private readonly IPiece[,] board = new IPiece[8, 8];

    public ChessBoard(Knight knight, Rook rook)
    {
        PlacePiece(knight);
        PlacePiece(rook);
    }

    public bool IsValidPosition(int x, int y)
    {
        return x >= 1 && x <= 8 && y >= 1 && y <= 8;
    }

    public void PlacePiece(IPiece piece)
    {
        board[piece.Position.X - 1, piece.Position.Y - 1] = piece;
    }

    public Rook GetRook()
    {
        return board.Cast<IPiece>().OfType<Rook>().FirstOrDefault();
    }

    public Knight GetKnight()
    {
        return board.Cast<IPiece>().OfType<Knight>().FirstOrDefault();
    }
}