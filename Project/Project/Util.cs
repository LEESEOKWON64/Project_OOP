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
    
    
    
}