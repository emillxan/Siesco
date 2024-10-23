using Task1.Entities.ChessPieces;

namespace ChessGame;

public class Game
{
    private ChessBoard board;
    private Knight knight;
    private Rook rook;
    private HashSet<(int X, int Y)> visitedPositions = new HashSet<(int X, int Y)>(); // Добавляем ходы в посещенные

    public Game(Knight knight, Rook rook)
    {
        this.knight = knight;
        this.rook = rook;
        this.board = new ChessBoard(knight, rook);
    }

    public void Play()
    {
        int moves = 0;
        Console.WriteLine($"Позиция ладьи: ({rook.Position.X}, {rook.Position.Y})");
        Console.WriteLine($"Текущая позиция коня: ({knight.Position.X}, {knight.Position.Y})");

        while (true)
        {
            moves++;
            var possibleMoves = knight.GetPossibleMoves(board); // Собираем все возможные ходы коня

            // Оценка клеток, с которых конь может атаковать ладью
            var rookAttackMoves = rook.GetPossibleMoves(board);
            var safeMoves = possibleMoves
                .Where(move => knight.IsMoveSafe(board, move)
                               && !rookAttackMoves.Contains(move)
                               && !visitedPositions.Contains(move)) // Избегаем повторных ходов
                .ToList();

            if (safeMoves.Count == 0)
            {
                Console.WriteLine("Конь не может сделать безопасный ход!");
                return;
            }

            // Ищем, может ли конь напасть на ладью
            if (knight.CanAttackRook(board, rook))
            {
                Console.WriteLine($"Конь съел ладью на ходу {moves}!");
                return;
            }

            // Выбираем следующий ход на основе оценки близости к клеткам, с которых можно атаковать ладью
            var nextMove = FindBestMoveTowardsRook(safeMoves, rook.Position);

            // Вывод текущей позиции коня и ладьи
            Console.WriteLine($"Ход {moves}:");
            Console.WriteLine($"Конь перемещается на ({nextMove.X}, {nextMove.Y})");

            // Вывод всех возможных ходов (включая те, которые небезопасные) и проверка угрозы ладьи
            Console.WriteLine("Все возможные ходы коня:");
            foreach (var move in possibleMoves)
            {
                bool isUnderRookAttack = rookAttackMoves.Contains(move);
                string status = isUnderRookAttack ? " (под угрозой ладьи)" : "";
                Console.WriteLine($"- ({move.X}, {move.Y}){status}");
            }

            // Обновляем позицию коня и добавляем её в посещенные
            knight.Move(nextMove);
            visitedPositions.Add(nextMove); // Добавляем ход в список посещенных
        }
    }

    private (int X, int Y) FindBestMoveTowardsRook(List<(int X, int Y)> safeMoves, (int X, int Y) rookPosition)
    {
        // Ищем ход, который минимизирует расстояние до ладьи
        return safeMoves.OrderBy(move => Math.Abs(move.X - rookPosition.X) + Math.Abs(move.Y - rookPosition.Y)).First();
    }
}
