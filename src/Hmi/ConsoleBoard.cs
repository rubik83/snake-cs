using System.Drawing;

namespace snake_cs.Hmi;

internal sealed class ConsoleBoard : Board
{
    private readonly ConsoleColor _savedBackgroundColor;

    private static Size GetSizeFromConsole()
    {
        return new Size(Console.WindowWidth - 4, Console.WindowHeight - 5);
    }

    internal ConsoleBoard()
    {
        Size = GetSizeFromConsole();
        _savedBackgroundColor = Console.BackgroundColor;
    }

    private static void DrawPoint(Point point, ConsoleColor color)
    {
        Console.BackgroundColor = color;
        Console.SetCursorPosition(point.X + 2, point.Y + 3);
        Console.Write(' ');
    }
    
    internal override void DrawPoint(Point point, Color color)
    {
        DrawPoint(point, (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Name));
    }

    internal override void WipePoint(Point point)
    {
        DrawPoint(point, ConsoleColor.Black);
    }

    internal override void DrawExit(string reason, int score)
    {
        Console.BackgroundColor = _savedBackgroundColor;
        Console.SetCursorPosition(0, Size.Height + 4);
        Console.WriteLine($"\n End ({reason}). Score : {score}");
        Console.CursorVisible = true;
    }

    internal override bool WindowChanged()
    {
        if (GetSizeFromConsole() == Size) return false;

        Size = GetSizeFromConsole();
        return true;
    }

    internal override void DrawBoard()
    {
        Console.SetCursorPosition(0, 0);
        Console.BackgroundColor = _savedBackgroundColor;
        Console.Clear();
        // write font advise
        Console.WriteLine("Use square font like \"Noto Color Emoji\"");
        Console.CursorVisible = false;
        // draw empty map
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(new string(' ', Size.Width + 4));
        Console.Write(' ');
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(new string(' ', Size.Width + 2));
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(' ');
        for (var line = 0; line < Size.Height; line++)
        {
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(new string(' ', Size.Width));
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(' ');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(' ');
        }

        Console.Write(' ');
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(new string(' ', Size.Width + 2));
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(' ');
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(new string(' ', Size.Width + 4));
    }
}
