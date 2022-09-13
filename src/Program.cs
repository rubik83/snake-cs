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

    public async Task Run()
    {
        while (_timer.IsRunning)
        {
            if (_hmi.Board.WindowChanged())
            {
                _apple.Bounds(_hmi.Board);
                _hmi.Board.DrawBoard();
                _apple.Draw(_hmi.Board);
                _snake.Draw(_hmi.Board);
            }

            _hmi.NextDirection();
            if (!_snake.Next(_hmi.Board, ref _apple, _hmi.Direction))
            {
                _timer.Cancel();
                Exit("GAME OVER");
                return;
            }

            await _timer.Wait();
        }
    }

    private void Exit(string reason)
    {
        _timer.Cancel();
        _hmi.Board.DrawExit(reason, _snake.Size);
    }
}
