using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Entities.ChessPieces;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var knight = new Knight(random.Next(1, 9), random.Next(1, 9));
            var rook = new Rook(random.Next(1, 9), random.Next(1, 9));

            while (knight.Position == rook.Position)
            {
                rook = new Rook(random.Next(1, 9), random.Next(1, 9));
            }

            Game game = new Game(knight, rook);
            game.Play();
        }
    }
}
