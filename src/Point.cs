namespace Snake;

using System.Drawing;

/// <summary>
///  Cardinal directions
/// </summary>
public enum Direction
{
    Up,
    Down,
    Left,
    Right,
}

/// <summary>
///  This class performs extentions for <c>System.Drawing.Point</c>
/// </summary>
public static class PointExtentions
{
    /// <summary>
    ///  Move <c>Point</c> <paramref name="point"/> of <c>1</c> in <c>Direction</c> <paramref name="direction"/>
    /// </summary>
    /// <param name="point">Point to move</param>
    /// <param name="direction">Direction to move to</param>
    public static void Move(ref this Point point, Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                point.Y -= 1;
                break;
            case Direction.Down:
                point.Y += 1;
                break;
            case Direction.Left:
                point.X -= 1;
                break;
            case Direction.Right:
                point.X += 1;
                break;
        }
    }

    /// <summary>
    /// Wraps each dimension beyond a maximum or under <c>0</c>
    /// </summary>
    /// <param name="point">Point to wrap</param>
    /// <param name="max">Maximum width/height value for X/Y</param>
    public static void Bounds(ref this Point point, Size max)
    {
        point.X = ScalarBounds(point.X, max.Width);
        point.Y = ScalarBounds(point.Y, max.Height);
    }

    private static int ScalarBounds(int v, int max_v)
    {
        if (v < 0)
        {
            return v + max_v;
        }
        if (v >= max_v)
        {
            return v - max_v;
        }
        return v;
    }
}
