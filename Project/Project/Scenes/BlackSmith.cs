namespace Project.Scenes;

public class BlackSmith
{
    private Stack<string> _script;
    private Weopon[] _weopons;
    
    
    private static BlackSmith instance;

    public static BlackSmith Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private BlackSmith()
    {
        _script = new Stack<string>();
        _weopons = new Weopon[11];
        
        for(int i = 0; i < _weopons.Length; i++)
        _weopons[0] = new Weopon()
            { Name = "이 빠진 검", Price = 5_000, Enforce = 0, SuccessProb = 1, FailProb = 0, DestructProb = 0 };
        _weopons[1] = new Weopon()
            { Name = "날카로운 검", Price = 7_000, Enforce = 1, SuccessProb = 0.9f, FailProb = 0.1f, DestructProb = 0 };
        _weopons[2] = new Weopon()
            { Name = "잘 제련된 검", Price = 9_000, Enforce = 2, SuccessProb = 0.8f, FailProb = 0.2f, DestructProb = 0.01f };
        _weopons[3] = new Weopon()
            { Name = "마력 깃든 검", Price = 12_000, Enforce = 3, SuccessProb = 0.7f, FailProb = 0.29f, DestructProb = 0.05f };
        _weopons[4] = new Weopon()
            { Name = "정령의 검", Price = 35_000, Enforce = 4, SuccessProb = 0.6f, FailProb = 0.35f, DestructProb = 0.1f };
        _weopons[5] = new Weopon()
            { Name = "빛을 품은 검", Price = 70_000, Enforce = 5, SuccessProb = 0.4f, FailProb = 0.4f, DestructProb = 0.2f };
        _weopons[6] = new Weopon()
            { Name = "천사의 검", Price = 200_000, Enforce = 6, SuccessProb = 0.2f, FailProb = 0.5f, DestructProb = 0.3f };
        _weopons[7] = new Weopon()
            { Name = "용사의 검", Price = 1_500_000, Enforce = 7, SuccessProb = 0.1f, FailProb = 0.55f, DestructProb = 0.35f };
        _weopons[8] = new Weopon()
            { Name = "영원의 검", Price = 20_000_000, Enforce = 8, SuccessProb = 0.05f, FailProb = 0.55f, DestructProb = 0.4f };
        _weopons[9] = new Weopon()
            { Name = "경일의 검", Price = 300_000_000, Enforce = 9, SuccessProb = 0.03f, FailProb = 0.47f, DestructProb = 0.5f };
        _weopons[10] = new Weopon()
            { Name = "엑스칼리버", Price = int.MaxValue, Enforce = 10, SuccessProb = 0.01f, FailProb = 0.39f, DestructProb = 0.6f };
    }

    public static BlackSmith GetInstance()
    {
        if (instance == null)
        {
            instance = new BlackSmith();
        }
        return instance;
    }
    
    public void Talk()
    {
        _script.Push("main");
        
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[터저스]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("무기를 강화할텐가? 한 번에 1000돈이라네");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("강화할수록 비싸게 팔 수 있지!");
        Console.SetCursorPosition(1,14);
        Util.PrintWordLine("하지만 무기가 터지는건 내 책임이 아니라고");
        Util.PrintWaiting();

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
                case "enforce":
                    Enforce();
                    break;
            }
        }
    }
    private void Main()
    {
        int decision = 11;
        Util.PrintTriangle(1,12, ref decision, out ConsoleKey newInput,"강화한다","떠난다");
        if (newInput == ConsoleKey.Escape) return;
        
        if (decision == 11)
        {
            _script.Push("enforce");
        }
        else
        {
            _script.Pop();
        }
    }
    
    private void Enforce()
    {
        if (Player.Instance.Weopon.Count == 0)
        {
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine("[터저스]");
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("음? 강화할 무기가 없잖나!");
            Util.PrintWaiting();
            _script.Pop();
            _script.Pop();
            return;
        }
        Random rate = new Random();
        int Rate = rate.Next(1, 101);
        int index = Array.IndexOf(_weopons, Player.Instance.Weopon[0]);
        Player.Instance.Money -= 1000;
        
        Console.SetCursorPosition(1,12);
        Util.PrintWord($"{Player.Instance.Weopon[0].Name}[{Player.Instance.Weopon[0].Enforce}] → {_weopons[index + 1].Name}[{_weopons[index + 1].Enforce}]"); 
        Console.SetCursorPosition(6,13);
        Util.PrintWordLine($"[강화 확률 : {(int)(Player.Instance.Weopon[0].SuccessProb*100)}%]");
        Util.PrintWaiting();
            
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(10,5);
        Util.PrintWordLine("깡 깡 깡",ConsoleColor.Yellow,400);

        if (Rate < Player.Instance.Weopon[0].SuccessProb * 100)
        {
            Success();
        }
        else if (Rate < (Player.Instance.Weopon[0].SuccessProb + Player.Instance.Weopon[0].FailProb) *
                 100)
        {
            Fail();
        }
        else
        {
            Destruct();
        }
        
    }

    private void Success()
    {
        int index = Array.IndexOf(_weopons, Player.Instance.Weopon[0]);
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(10,5);
        Util.PrintWordLine("[강화를 성공했습니다]");
        Console.SetCursorPosition(1,12);
        Util.PrintWord($"{Player.Instance.Weopon[0].Name}[{Player.Instance.Weopon[0].Enforce}]");
        Util.PrintWordLine($" → {_weopons[index + 1].Name}[{_weopons[index + 1].Enforce}]"); 
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[터저스]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("하, 이 정도야 기본이지");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("다음 번에도 무기 강화는 맡겨주게!");
        Util.PrintWaiting();
        
        Player.Instance.Weopon[0] = _weopons[index + 1];
        _script.Pop();
    }

    private void Fail()
    {
        int index = Array.IndexOf(_weopons, Player.Instance.Weopon[0]);

        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(10,5);
        Util.PrintWordLine("[강화를 실패했습니다]");
        Console.SetCursorPosition(1,12);
        Util.PrintWord($"{Player.Instance.Weopon[0].Name}[{Player.Instance.Weopon[0].Enforce}]");
        Util.PrintWordLine($" → {_weopons[index - 1].Name}[{_weopons[index - 1].Enforce}]"); 
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[터저스]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("아이쿠 손이 미끄러졌구먼 허허");
        Util.PrintWaiting();

        Player.Instance.Weopon[0] = _weopons[index - 1];
        _script.Pop();
    }

    private void Destruct()
    {
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(10,5);
        Util.PrintWordLine("[장비가 파괴됐습니다]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine($"{Player.Instance.Weopon[0].Name}[{Player.Instance.Weopon[0].Enforce}] → 파괴!");
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[터저스]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("아이쿠.. 눈에 땀이 들어갔구만 미안혀");
        Util.PrintWaiting();

        Player.Instance.Weopon.RemoveAt(0);
        _script.Pop();
    }
}