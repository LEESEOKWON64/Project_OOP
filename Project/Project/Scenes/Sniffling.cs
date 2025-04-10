namespace Project.Scenes;

public class Sniffling
{
    private Stack<string> _script;
    private int _betting;
    private int _count;
    private float _rate;
    private string _choice;
    private int _result;
    
    
    private static Sniffling instance;
    public static Sniffling Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private Sniffling()
    {
        _script = new Stack<string>();
        _count = 1;
        _rate = 1.0f;
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
                case "intro":
                    Intro();
                    break;
                case "play":
                    Play();
                    break;
                case "result":
                    Result();
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

            _script.Push("intro");
        }
    }

    private void Intro()
    {
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("홀짝게임은 최대 7회까지 진행되며", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("게임 진행 도중 포기는 불가능합니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("그럼, 홀짝 게임 시작합니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        _script.Push("play");
    }

    private void Play()
    {
        int decision = 13;
        Random rnd = new Random();
        _result = rnd.Next(0, 10);
        
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"제 {_count}회 홀짝 맞추기를 시작합니다", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("홀이냐, 짝이냐... 선택해주세요", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"[배당 : {_betting} X {_rate.ToString("0.0")}]", ConsoleColor.White, 20);
        Util.PrintTriangle(1,13, ref decision, out ConsoleKey newInput,"「홀」에 베팅", "「짝」에 베팅" );

        if (decision == 13) _choice = "홀";
        else _choice = "짝";
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"숫자는 {_result}이며, {Judgement(_result)}입니다", ConsoleColor.White, 20);
        Util.PrintWaiting();

        if (Judgement(_result) == _choice)
        {
            _rate += 0.3f;
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 12);
            Util.PrintWordLine("홀짝 맞추기에 성공하셨습니다", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 13);
            Util.PrintWordLine("(배당 + 0.3)", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 14);
            Util.PrintWordLine($"[배당 : {_betting} X {_rate.ToString("0.0")}]", ConsoleColor.White, 20);
        }
        else
        {
            _rate -= 0.3f;
            if (_rate < 0) _rate = 0.0f;
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 12);
            Util.PrintWordLine("홀짝 맞추기에 실패하셨습니다", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 13);
            Util.PrintWordLine("(배당 - 0.3)", ConsoleColor.White, 20);
            Console.SetCursorPosition(1, 14);
            Util.PrintWordLine($"[배당 : {_betting} X {_rate.ToString("0.0")}]", ConsoleColor.White, 20);
        }
        Util.PrintWaiting();
        _count += 1;

        if (_count == 8)
        {
            _script.Push("result");
        }
    }

    private void Result()
    {
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("홀짝 게임 7회차가 모두 종료되었습니다", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("최종 금액을 정산합니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"{_betting} X {_rate.ToString("0.0")}으로", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine($"총 {(int)(_betting*_rate)}돈을 따내셨습니다", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"다만, 여기서 수수료 5%를 차감해", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine($"총 {(int)(_betting * _rate * 0.95)}돈을 드리겠습니다", ConsoleColor.White, 20);
        Util.PrintWaiting();

        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"{(int)(_betting * _rate * 0.95)}돈을 땄습니다!", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[도박꾼]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine($"다음번에도 들러주시길...", ConsoleColor.White, 20);
        Util.PrintWaiting();
        
        Player.Instance.Money += (int)(_betting * _rate * 0.95);
        _count = 1;
        _script.Pop();
        _script.Pop();
        _script.Pop();
        _script.Pop();
    }
    
    private string Judgement(int num)
    {
        if (num % 2 == 0) return "짝";
        return "홀";
    }
}