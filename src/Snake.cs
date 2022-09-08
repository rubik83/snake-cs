using System.Drawing;

namespace snake_cs;

public class Snake
{
    private readonly LinkedList<Point> _coords;
    public int Size { get; private set; }

    public Snake(in Board board)
    {
        _coords = new LinkedList<Point>();
        Size = 10;
        _coords.AddLast(new Point(board.Size / 2));
    }
    public void Draw(in Board board)
    {
        foreach (Point p in _coords)
        {
            board.DrawPoint(p, ConsoleColor.Blue);
        }
    }
    public bool Next(in Board board, ref Apple apple, Direction direction)
    {
        var head = _coords.Last();
        head.Move(direction);
        head.Bounds(board.Size);
        if (_coords.Contains(head))
        {
            return false;
        }
        _coords.AddLast(head);

        if (_coords.Last() == apple.Position)
        {
            Size += 5;
            Apple.Change(ref apple, board, _coords);
        }

        board.DrawPoint(_coords.Last(), ConsoleColor.Blue);

        if (_coords.Count > Size)
        {
            board.DrawPoint(_coords.First(), ConsoleColor.Black);
            _coords.RemoveFirst();
        }

        return true;
    }
}
