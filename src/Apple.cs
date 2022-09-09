using System.Drawing;
using System.Security.Cryptography;

namespace snake_cs;

internal struct Apple
{
    internal Point Position { get; private set; }
    internal int Size { get; private set; }

    internal Apple(in Board board, LinkedList<Point>? exclude)
    {
        do
        {
            Position = new Point
            {
                X = RandomNumberGenerator.GetInt32(0, board.Size.Width),
                Y = RandomNumberGenerator.GetInt32(0, board.Size.Height),
            };
        } while (exclude is not null && exclude.Contains(Position));

        Size = RandomNumberGenerator.GetInt32(1, 4);
    }

    internal void Bounds(Board board)
    {
        var p = Position;
        p.Bounds(board.Size);
        Position = p;
    }

    private Color GetColor()
    {
        return Size switch
        {
            1 => Color.Green,
            2 => Color.Yellow,
            3 => Color.Red,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    internal void Draw(in Board board)
    {
        board.DrawPoint(Position, GetColor());
    }

    internal static void Change(ref Apple apple, in Board board, in LinkedList<Point> snakeCoords)
    {
        board.WipePoint(apple.Position);
        apple = new Apple(board, snakeCoords);
        apple.Draw(board);
    }
}
