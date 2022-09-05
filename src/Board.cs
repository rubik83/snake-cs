using System.Drawing;

namespace Snake
{
    public class Board
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        private ConsoleColor SavedBackgroundColor;

        public Board()
        {
            Rows = 30;
            Columns = 30;
            SavedBackgroundColor = Console.BackgroundColor;
        }

        public void DrawPoint(Point point, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(point.X + 2, point.Y + 3);
            Console.Write(' ');
        }

        public void DrawExit(string reason, int score)
        {
            Console.BackgroundColor = SavedBackgroundColor;
            Console.SetCursorPosition(0, Rows + 4);
            Console.WriteLine($"\n End ({reason}). Score : {score}");
            Console.CursorVisible = true;
        }

        public void DrawBoard()
        {
            Console.Clear();
            // write font advise
            Console.WriteLine("Use square font like \"Noto Color Emoji\"");
            Console.CursorVisible = false;
            // draw empty map
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(new string(' ', this.Columns + 4));
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(new string(' ', this.Columns + 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(' ');
            for (int line = 0; line < this.Rows; line++)
            {
                Console.Write(' ');
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(' ');
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(new string(' ', this.Columns));
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(' ');
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(' ');
            }
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(new string(' ', this.Columns + 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(new string(' ', this.Columns + 4));
        }
    }
}
