namespace snake_cs;

public class Keyboard
{
    public Direction Direction { get; private set; }

    public Keyboard()
    {
        Direction = Direction.Up;
    }

    public void NextDirection()
    {
        bool keyAvailable = false;
        try
        {
            keyAvailable = Console.KeyAvailable;
        }
        catch { }
        if (keyAvailable)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    Direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    Direction = Direction.Right;
                    break;

            }
        }
    }
}
