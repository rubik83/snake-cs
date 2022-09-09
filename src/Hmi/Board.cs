using System.Drawing;

namespace snake_cs.Hmi;

internal abstract class Board
{
    protected internal Size Size { get; protected set; }

    internal abstract void DrawPoint(Point point, Color color);

    internal abstract void WipePoint(Point point);

    internal abstract void DrawExit(string reason, int score);

    internal abstract bool WindowChanged();

    internal abstract void DrawBoard();
}
