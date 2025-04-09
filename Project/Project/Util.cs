using System.Xml.Xsl;

namespace Project;

public static class Util
{
    public static void FieldTriangle(string nickname, string place, int x = 0, int y = 8)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine($"{nickname}(으)로 이동하시겠습니까?");
        Console.SetCursorPosition(x + 1, y + 1);
        Console.Write("이동한다.");
        Console.SetCursorPosition(x + 1, y + 2);
        Console.Write("이동하지 않는다.");
        Console.SetCursorPosition(x, y + 1);
        Console.Write("▶");
        ConsoleKey newInput = Console.ReadKey().Key;
        while (newInput != ConsoleKey.Enter)
        {
            
            if ((Console.GetCursorPosition() == (x + 1, y + 1)) &&
                newInput == ConsoleKey.DownArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write("▶");
            }
            else if ((Console.GetCursorPosition() == (x + 1, y + 2)) &&
                     newInput == ConsoleKey.UpArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("▶");
            }

            newInput = Console.ReadKey().Key;
        }

        if (Console.GetCursorPosition() == (x, y + 1))
        {
            Player.Instance.PrevPlace = Player.Instance.CurrentPlace;
            Player.Instance.NextPlace = GameManager.Instance.Places[place];
        }
    }
    
    public static void PrintLine(string context, int delay = 0, ConsoleColor textColor = ConsoleColor.White)
    {
        Console.ForegroundColor = textColor;
        Console.WriteLine(context);
        Thread.Sleep(delay);
        Console.ResetColor();
    }
    
    public static void Print(string context, int delay = 0, ConsoleColor textColor = ConsoleColor.White)
    {
        Console.ForegroundColor = textColor;
        Console.Write(context);
        Thread.Sleep(delay);
        Console.ResetColor();
    }

    public static void PrintWordLine(string context, ConsoleColor textColor = ConsoleColor.White, int delay = 60)
    {
        Console.ForegroundColor = textColor;
        for(int i = 0; i < context.Length; i++)
        {
            Console.Write(context[i]);
            Thread.Sleep(delay);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.ResetColor();
    }
    
    public static void PrintWord(string context, ConsoleColor textColor = ConsoleColor.White, int delay = 60)
    {
        Console.ForegroundColor = textColor;
        for(int i = 0; i < context.Length; i++)
        {
            Console.Write(context[i]);
            Thread.Sleep(delay);
        }
        Thread.Sleep(60);
        Console.ResetColor();
    }

    public static void PrintTriangle(int x, int y, ref int decision, params string[] message)
    {
        int left;
        int right;
        int a;

        for (int i = 0; i < message.Length; i++)
        {
            Console.SetCursorPosition(x + 1, y + i);
            Console.WriteLine(message[i]);
        }

        Console.SetCursorPosition(x, y);
        Console.Write("▶");
        ConsoleKey newInput = Console.ReadKey().Key;
        (left, right) = Console.GetCursorPosition();
        while (newInput != ConsoleKey.Enter)
        {
            if (right <= y && (right + message.Length - 1) > y && newInput == ConsoleKey.DownArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x, ++y);
                Console.Write("▶");
            }
            else if (right < y && (right + message.Length - 1) >= y &&
                     newInput == ConsoleKey.UpArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x, --y);
                Console.Write("▶");
            }
            (a, decision) = Console.GetCursorPosition();
            newInput = Console.ReadKey().Key;
        }
    }

    public static void PrintWaiting()
    {
        Console.CursorVisible = false;
        int left;
        int right;
        (left, right) = Console.GetCursorPosition();
        Console.SetCursorPosition(left+10, right + 1);
        while (!Console.KeyAvailable)
        {
            PrintWord("▼",ConsoleColor.DarkYellow,400);
            Console.Write("\b \b");
            Thread.Sleep(400);
        }
        Console.ReadKey(true);
    }
    
    public static void PrintSideTriangle(int x, int y, ref int decision, params string[] message )
    {
        int left;
        int right;
        int b = 0;
        
        for (int i = 0; i < message.Length; i++)
        {
            Console.SetCursorPosition(x + 1 + 10*i, y);
            Console.WriteLine(message[i]);
        }
        
        Console.SetCursorPosition(x, y);
        Console.Write("▶");
        ConsoleKey newInput = Console.ReadKey().Key;
        (left, right) = Console.GetCursorPosition();
        while (newInput != ConsoleKey.Enter)
        {
            if (left - 1 <= x && (left - 1 + (message.Length - 1) * 10) > x 
                              && newInput == ConsoleKey.RightArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x+=10, y);
                Console.Write("▶");
            }
            else if (left - 1 < x && (left - 1 + (message.Length - 1) * 10) >= x 
                                  && newInput == ConsoleKey.LeftArrow)
            {
                Console.Write("\b");
                Console.Write(" ");
                Console.SetCursorPosition(x-=10, y);
                Console.Write("▶");
            }

            (decision, b) = Console.GetCursorPosition();
            newInput = Console.ReadKey().Key;
        }
    }

    public static void PrintCount(string type, Coin coin, out int num)
    {
        int left;
        int right;
        (left,right) = Console.GetCursorPosition();
        
        ConsoleKey input = ConsoleKey.A;
        num = 0;
        if (type == "buy")
        {
            while (input != ConsoleKey.Enter)
            {
                if (num < 99 && input == ConsoleKey.UpArrow && (num + 1) * coin.Price < Player.Instance.Money) num++;
                else if (num > 0 && input == ConsoleKey.DownArrow) num--;
                Console.SetCursorPosition(left,right);
                Console.Write("\b\b");
                Console.Write("  ");
                Console.Write("\b\b\b");
                Console.Write(num.ToString().PadLeft(3));
            
                Console.SetCursorPosition(left+13,right);
                Console.Write("\b\b\b\b\b\b");
                Console.Write("  ");
                Console.Write("\b\b\b\b\b\b\b");
                Console.Write($"{(num*coin.Price).ToString().PadLeft(7)}돈");
            
                input = Console.ReadKey().Key;
            }
        }
        else if (type == "sell")
        {
            while (input != ConsoleKey.Enter)
            {
                if (num < coin.count && input == ConsoleKey.UpArrow) num++;
                else if (num > 0 && input == ConsoleKey.DownArrow) num--;
                Console.SetCursorPosition(left,right);
                Console.Write("\b\b");
                Console.Write("  ");
                Console.Write("\b\b\b");
                Console.Write(num.ToString().PadLeft(3));
            
                Console.SetCursorPosition(left+13,right);
                Console.Write("\b\b\b\b\b\b");
                Console.Write("  ");
                Console.Write("\b\b\b\b\b\b\b");
                Console.Write($"{(num*coin.Price).ToString().PadLeft(7)}돈");
            
                input = Console.ReadKey().Key;
            }
        }
    }
}