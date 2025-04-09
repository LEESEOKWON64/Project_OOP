using System.Net;

namespace Project.Scenes;

public class Merchant
{
    private Stack<string> _script;
    
    private static Merchant instance;
    public static Merchant Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private Merchant()
    {
        _script = new Stack<string>();
    }
    
    public static Merchant GetInstance()
    {
        if (instance == null)
        {
            instance = new Merchant();
        }
        return instance;
    }
    
    public void Talk()
    {
        _script.Push("main");

        while (_script.Count > 0)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            string curScript = _script.Peek();
            switch (curScript)
            {
                case "main":
                    Main();
                    break;
            }
        }
    }

    private void Main()
    {
        int decision1 = 0;
        int decision2 = 0;
        Console.SetCursorPosition(38, 1);
        Console.Write($"{Player.Instance.Money}돈");
        Util.PrintSideTriangle(2, 1, ref decision1, "구입한다", "매각한다", "그만둔다");
        Console.WriteLine(decision1);

        if (decision1 <= 6)
        {
            if (Player.Instance.Weopon.Count == 0)
            {
                Util.PrintTriangle(3, 4, ref decision2, out ConsoleKey newInput,
                    $"{"이 빠진 검".PadRight(3)}{"5000돈".PadLeft(10)}", "그만둔다");

                if (newInput == ConsoleKey.Escape) return;

                if (decision2 <= 4)
                {
                    Console.SetCursorPosition(3, 8);
                    Util.PrintWordLine("[구매 했습니다]");
                    Util.PrintWaiting();
                    Player.Instance.Money -= 5000;
                    Player.Instance.Weopon.Add(new Weopon()
                    {
                        Name = "이 빠진 검", Price = 5_000, Enforce = 0, SuccessProb = 1, FailProb = 0, DestructProb = 0
                    });
                }
            }
            else
            {
                Console.SetCursorPosition(3, 8);
                Util.PrintWordLine("[더 이상 구매할 수 없습니다]");
                Util.PrintWaiting();
            }
        }
        else if (decision1 == 13)
        {
            if (Player.Instance.Weopon.Count == 0) return;

            Util.PrintTriangle(3, 4, ref decision2, out ConsoleKey newInput,
                $"{Player.Instance.Weopon[0].Name.PadRight(3)}{(Player.Instance.Weopon[0].Price + "돈").ToString().PadLeft(10)}","그만둔다");
            if (newInput == ConsoleKey.Backspace) return;
            if (decision2 <= 4) 
            {
                Console.SetCursorPosition(3,8);
                Util.PrintWordLine("[판매 했습니다]");
                Player.Instance.Money += Player.Instance.Weopon[0].Price;
                Player.Instance.Weopon = new List<Weopon>();
                Util.PrintWaiting();
            }
        }
        else if(decision1 == 23)
        {
            _script.Pop();
        }
    }
}