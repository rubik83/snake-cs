namespace snake_cs.Hmi;

internal sealed class ConsoleHmi : IHmi
{
    public Board Board { get; } = new ConsoleBoard();
    public Direction Direction { get; private set; }

    public ConsoleHmi(Action<string> endAction)
    {
        Console.CancelKeyPress += (_, _) => endAction("CTRL+C");
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

    public void SetEndAction(Action<string> action)
    {
        Console.CancelKeyPress += (_, _) => action("CTRL+C");
    }
}
