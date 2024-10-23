using Task1.Entities.ChessPieces.Base;

namespace Task1.Entities.ChessPieces;

public class Knight : Piece
{
    public Knight(int x, int y)
    {
        Position = (x, y);
    }

    public override List<(int X, int Y)> GetPossibleMoves(ChessBoard board)
    {
        var possibleMoves = new List<(int X, int Y)>
            {
                (Position.X + 2, Position.Y + 1),
                (Position.X + 2, Position.Y - 1),
                (Position.X - 2, Position.Y + 1),
                (Position.X - 2, Position.Y - 1),
                (Position.X + 1, Position.Y + 2),
                (Position.X + 1, Position.Y - 2),
                (Position.X - 1, Position.Y + 2),
                (Position.X - 1, Position.Y - 2),
            };

        return possibleMoves.Where(move => board.IsValidPosition(move.X, move.Y)).ToList();
    }

    public override bool IsMoveSafe(ChessBoard board, (int X, int Y) move)
    {
        var rook = board.GetRook();
        return rook == null || (rook.Position.X != move.X && rook.Position.Y != move.Y);
    }

    public void Move((int X, int Y) newPosition)
    {
        Position = newPosition;
    }

    public bool CanAttackRook(ChessBoard board, Rook rook)
    {
        var attackMoves = GetPossibleMoves(board);
        return attackMoves.Any(m => m == rook.Position);
    }
}

