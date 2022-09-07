namespace Snake;

using System.Drawing;

public class Snake
{
    public LinkedList<Point> Coords { get; private set; }
    public int Size { get; private set; }

    public Snake(in Board board)
    {
        Coords = new LinkedList<Point>();
        Size = 10;
        Coords.AddLast(new Point(board.Size / 2));
    }
    public void Draw(in Board board)
    {
        foreach (Point p in Coords)
        {
            board.DrawPoint(p, ConsoleColor.Blue);
        }
    }
    public bool Next(in Board board, ref Apple apple, Direction direction)
    {
        var head = Coords.Last();
        head.Move(direction);
        head.Bounds(board.Size);
        if (Coords.Contains(head))
        {
            return false;
        }
        Coords.AddLast(head);

        if (Coords.Last() == apple.Position)
        {
            Size += 5;
            Apple.Change(ref apple, board, Coords);
        }

        board.DrawPoint(Coords.Last(), ConsoleColor.Blue);

        if (Coords.Count > Size)
        {
            board.DrawPoint(Coords.First(), ConsoleColor.Black);
            Coords.RemoveFirst();
        }

        return true;
    }
}
