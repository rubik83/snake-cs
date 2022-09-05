using System.Drawing;

namespace Snake
{
    static class Program
    {
        static Board Board = new Board();
        static Apple Apple = new Apple(Board, null);
        static Snake Snake = new Snake(Board);
        static Timer Timer = new Timer();
        static Keyboard Keyboard = new Keyboard();

        public static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, args) =>
            {
                Exit("CTRL+C");
            };

            Board.DrawBoard();

            Apple.Draw(Board);

            // run
            while (Timer.Run)
            {
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

        private static void Exit(string reason)
        {
            Timer.Run = false;
            Board.DrawExit(reason, Snake.Size);
        }
    }

}
