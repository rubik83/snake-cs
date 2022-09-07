namespace Snake;

public class Program
{
    Board Board;
    Apple Apple;
    Snake Snake;
    Timer Timer;
    Keyboard Keyboard;

    public Program()
    {
        Board = new Board();
        Apple = new Apple(Board, null);
        Snake = new Snake(Board);
        Timer = new Timer();
        Keyboard = new Keyboard();

        Console.CancelKeyPress += (sender, args) => Exit("CTRL+C");

        Board.DrawBoard();
        Apple.Draw(Board);
        Snake.Draw(Board);
    }

    public void Run()
    {
        while (Timer.Run)
        {
            if (Board.WindowChanged())
            {
                Apple.Bounds(Board);
                Board.DrawBoard();
                Apple.Draw(Board);
                Snake.Draw(Board);
            }
            Keyboard.NextDirection();
            if (!(Snake.Next(Board, ref Apple, Keyboard.Direction)))
            {
                Timer.Run = false;
                Exit("GAME OVER");
                return;
            }
            Timer.Wait();
        }
    }

    private void Exit(string reason)
    {
        Timer.Run = false;
        Board.DrawExit(reason, Snake.Size);
    }
}
