using Task1.Entities.ChessPieces.Base;

namespace Task1.Entities.ChessPieces
{
    public class Rook : Piece
    {
        public Rook(int x, int y)
        {
            Position = (x, y);
        }

        public override List<(int X, int Y)> GetPossibleMoves(ChessBoard board)
        {
            return Enumerable.Range(1, 8)
                             .SelectMany(i => new List<(int X, int Y)>
                             {
                                 (i, Position.Y),
                                 (Position.X, i)
                             }).ToList();
        }

        public override bool IsMoveSafe(ChessBoard board, (int X, int Y) move)
        {
            return true;
        }
    }
}
