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
        if (!Console.KeyAvailable) return;
        var key = Console.ReadKey();
        Direction = key.Key switch
        {
            ConsoleKey.UpArrow => Direction.Up,
            ConsoleKey.DownArrow => Direction.Down,
            ConsoleKey.LeftArrow => Direction.Left,
            ConsoleKey.RightArrow => Direction.Right,
            _ => Direction
        };
    }
}
