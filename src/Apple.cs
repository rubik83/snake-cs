using System.Drawing;
using System.Security.Cryptography;

namespace Snake
{
    public struct Apple
    {
        public Point Position { get; private set; }
        public int Size { get; private set; }

        public Apple(in Board board, LinkedList<Point>? exclude)
        {
            do
            {
                Position = new Point
                {
                    X = RandomNumberGenerator.GetInt32(0, board.Columns),
                    Y = RandomNumberGenerator.GetInt32(0, board.Rows),
                };
            }
            while (exclude is not null && exclude.Contains(Position));
            Size = RandomNumberGenerator.GetInt32(1, 3);
        }

        public void Draw(Board board)
        {
            board.DrawPoint(this.Position, ConsoleColor.Red);
        }

        public static void Change(ref Apple apple, in Board board, in LinkedList<Point> snake_coords)
        {
            board.DrawPoint(apple.Position, ConsoleColor.Black);
            apple = new Apple(board, snake_coords);
            apple.Draw(board);
        }
    }
}
