using System.Drawing;
using snake_cs.Hmi;

namespace snake_cs;

internal sealed class Snake
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
        foreach (var p in _coords) board.DrawPoint(p, Color.Blue);
    }

    public bool Next(in Board board, ref Apple apple, Direction direction)
    {
        var head = _coords.Last();
        head.Move(direction);
        head.Bounds(board.Size);
        if (_coords.Contains(head)) return false;

        _coords.AddLast(head);

        if (_coords.Last() == apple.Position)
        {
            Size += 3 * apple.Size;
            Apple.Change(ref apple, board, _coords);
        }

        board.DrawPoint(_coords.Last(), Color.Blue);

        if (_coords.Count <= Size) return true;

        board.WipePoint(_coords.First());
        _coords.RemoveFirst();

        return true;
    }
}
