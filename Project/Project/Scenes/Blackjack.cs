namespace Project.Scenes;

public class Blackjack
{
    private Stack<string> _script;
    
    private static Blackjack instance;
    public static Blackjack Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private Blackjack()
    {
        _script = new Stack<string>();
    }
    
    public static Blackjack GetInstance()
    {
        if (instance == null)
        {
            instance = new Blackjack();
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
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("[블랙잭 딜러가 경이리를 쳐다보고 있다]");
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[개발자]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("블랙잭은 묵시록 난이도 클리어시 해금됩니다");
        Util.PrintWaiting();

        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[개발자]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("사실 아직 미구현이지롱!");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("제출 30분 남은거 실화냐!!!!!");
        Util.PrintWaiting();
        _script.Pop();
    }
}