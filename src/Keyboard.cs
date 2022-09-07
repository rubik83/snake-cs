namespace Snake;

public class Keyboard
{
    public Direction Direction { get; private set; }

    public Keyboard()
    {
        Direction = Direction.Up;
    }

    public void NextDirection()
    {
        bool key_available = false;
        try
        {
            key_available = Console.KeyAvailable;
        }
        catch { }
        if (key_available)
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
