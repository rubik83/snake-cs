using System.Drawing;

namespace Snake
{
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
        /// <param name="max_x">Maximum value for dimention <c>X</c></param>
        /// <param name="max_y">Maximum value for dimention <c>Y</c></param>
        public static void Bounds(ref this Point point, int max_x, int max_y)
        {
            point.X = ScalarBounds(point.X, max_x);
            point.Y = ScalarBounds(point.Y, max_y);
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
}
