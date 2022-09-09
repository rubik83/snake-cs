using snake_cs.Hmi;

namespace snake_cs;

internal sealed class Program
{
    private readonly IHmi _hmi;
    private Apple _apple;
    private readonly Snake _snake;
    private readonly Timer _timer;

    public Program()
    {
        _hmi = new ConsoleHmi(Exit);
        _apple = new Apple(_hmi.Board, null);
        _snake = new Snake(_hmi.Board);
        _timer = new Timer();

        _hmi.Board.DrawBoard();
        _apple.Draw(_hmi.Board);
        _snake.Draw(_hmi.Board);
    }

    public void Run()
    {
        while (_timer.Run)
        {
            if (_hmi.Board.WindowChanged())
            {
                _apple.Bounds(_hmi.Board);
                _hmi.Board.DrawBoard();
                _apple.Draw(_hmi.Board);
                _snake.Draw(_hmi.Board);
            }

            _hmi.NextDirection();
            if (!(_snake.Next(_hmi.Board, ref _apple, _hmi.Direction)))
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
        _hmi.Board.DrawExit(reason, _snake.Size);
    }
}
