namespace Project.Scenes;

public class Sniffling
{
    private Stack<string> _script;
    private int _betting;
    
    
    private static Sniffling instance;
    public static Sniffling Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private Sniffling()
    {
        _script = new Stack<string>();
    }
    
    public static Sniffling GetInstance()
    {
        if (instance == null)
        {
            instance = new Sniffling();
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
                case "level":
                    Level();
                    break;
                case "play":
                    Play();
                    break;
                    
            }
        }
    }

    private void Main()
    {
        int decision1 = 12;
        int decision2 = 12;
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("홀짝 한 판하고 가세요", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("이득 보기 쉬운 게임입니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1, 12, ref decision1, out ConsoleKey newInput, "베팅액을 제시한다", "그만둔다");
        if (decision1 == 12)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Util.PrintSideTriangleForNum(3, 12, ref decision2, Player.Instance.bet);
            _betting = Util.Transbet();
            if (_betting > Player.Instance.Money)
            {
                Console.Clear();
                GameManager.Instance.PrintScreen();
                Console.SetCursorPosition(1, 12);
                Util.PrintWordLine("[보유하고 있는 돈보다 많이 입력했습니다]");
                Util.PrintWaiting();
                Util.ResetArr(Player.Instance.bet);
                return;
            }
            else
            {
                Console.Clear();
                GameManager.Instance.PrintScreen();
                Console.SetCursorPosition(1, 12);
                Util.PrintWordLine($"[{_betting}돈을 베팅합니다]");
                Player.Instance.Money -= _betting;
                Util.PrintWaiting();
                Util.ResetArr(Player.Instance.bet);
            }

            _script.Push("play");
        }
    }

    private void Play()
    {
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("홀짝게임은 최대 7회까지 진행되며", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("게임 진행 도중 포기는 불가능합니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
    }
}