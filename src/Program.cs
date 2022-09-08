namespace snake_cs;

internal sealed class Program
{
    private readonly Board _board;
    private Apple _apple;
    private readonly Snake _snake;
    private readonly Timer _timer;
    private readonly Keyboard _keyboard;

    public Program()
    {
        _board = new Board();
        _apple = new Apple(_board, null);
        _snake = new Snake(_board);
        _timer = new Timer();
        _keyboard = new Keyboard();

        Console.CancelKeyPress += (_, _) => Exit("CTRL+C");

        _board.DrawBoard();
        _apple.Draw();
        _snake.Draw(_board);
    }

    public void Run()
    {
        while (_timer.Run)
        {
            if (_board.WindowChanged())
            {
                _apple.Bounds(_board);
                _board.DrawBoard();
                _apple.Draw();
                _snake.Draw(_board);
            }

            _keyboard.NextDirection();
            if (!(_snake.Next(_board, ref _apple, _keyboard.Direction)))
            {
                _timer.Run = false;
                Exit("GAME OVER");
                return;
            }

            _timer.Wait();
        }
    }

    private void Exit(string reason)
    {
        _timer.Run = false;
        _board.DrawExit(reason, _snake.Size);
    }
}
