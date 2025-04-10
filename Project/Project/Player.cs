using Project.Places;
using Project.Scenes;

namespace Project;

public class Player
{
    private string _name;
    private char _symbol;
    private ConsoleColor _color;
    public int[] bet { get; set; }
    private List<Weopon> _weopon;
    public List<Weopon> Weopon
    {
        get => _weopon;
        set => _weopon = value;
    }
    
    private int _money;
    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }

    private Place _currentPlace;
    public Place CurrentPlace
    {
        get { return _currentPlace; }
        set { _currentPlace = value; }
    }

    private Place _prevPlace;
    public Place PrevPlace
    {
        get { return _prevPlace; }
        set { _prevPlace = value; }
    }
    
    private Place _nextPlace;
    public Place NextPlace
    {
        get { return _nextPlace; }
        set { _nextPlace = value; }
    }
    
    private static Player instance;
    public static Player Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    
    private Vector2 _position;
    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public static void GetInstance()
    {
        if (instance == null)
        {
            instance = new Player();
        }
    }

    private Player()
    {
        _name = "경이리";
        _symbol = 'P';
        _color = ConsoleColor.White;
        _money = 150_000;
        bet = new int[6]{0,0,0,0,0,0};
        _currentPlace = GameManager.Instance.Places["casino"];
        _prevPlace = GameManager.Instance.Places["casino"];
        _nextPlace = GameManager.Instance.Places["casino"];
        _position = new Vector2(32,7);
        Weopon = new List<Weopon>();
    }
    public void Action(ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.UpArrow :
            case ConsoleKey.DownArrow :
            case ConsoleKey.LeftArrow :
            case ConsoleKey.RightArrow :
                Move(input);
                break;
            case ConsoleKey.I :
                Open();
                break;
        }
    }
    
    public void Move(ConsoleKey input)
    {
        Vector2 nextPos = _position;
        switch (input)
        {
            case ConsoleKey.UpArrow:
                nextPos.y--;
                break;
            case ConsoleKey.DownArrow:
                nextPos.y++;
                break;
            case ConsoleKey.LeftArrow:
                nextPos.x--;
                break;
            case ConsoleKey.RightArrow:
                nextPos.x++;
                break;
        }

        if (_currentPlace.Name == "field")
        {
            if (_currentPlace.Map[nextPos.y-1, nextPos.x-16] == '#')
            {
                _position = nextPos;
            }
        }
        else
        {
            if (_currentPlace.Map[nextPos.y-1, nextPos.x-16] == ' ')
            {
                _position = nextPos;
            }
        }
    }

    public void SetPosition(Vector2 Position)
    {
        _position = Position;
    }
    
    public void Print()
    {
        Console.SetCursorPosition(_position.x, _position.y);
        Console.ForegroundColor = _color;
        Console.WriteLine(_symbol);
        Console.ResetColor();
    }

    private void Open()
    {
        Computer.GetIntance();
        
        Console.Clear();
        int decision1 = 3;
        int decision2 = 4;
        int decision3 = 6;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(38,1);
        Console.Write($"{Money}돈");
        
        Util.PrintSideTriangle(2, 1, ref decision1,"가방", "포기하기", "그만둔다");

        if (decision1 == 3)
        {
            Util.PrintTriangle(3, 4, ref decision2, out ConsoleKey newInput,
                $"{Computer.Instance._coins[0].Name.PadRight(3)}{Computer.Instance._coins[0].count.ToString().PadLeft(10)}", 
                              $"{Computer.Instance._coins[1].Name.PadRight(3)}{Computer.Instance._coins[1].count.ToString().PadLeft(10)}", 
                              $"{Computer.Instance._coins[2].Name.PadRight(3)}{Computer.Instance._coins[2].count.ToString().PadLeft(10)}","그만둔다");
            return;
        }
        else if (decision1 == 13)
        {
            Console.SetCursorPosition(3,4);
            Util.PrintWordLine("지금까지 진행한 데이터가 사라집니다");
            Console.SetCursorPosition(3,5);
            Util.PrintWordLine("정말로 포기하시겠습니까?");
            Util.PrintTriangle(3, 6, ref decision3, out ConsoleKey newInput, "계속한다", "포기한다");
            if (decision3 == 6) return;
            GiveUp();
        }
        else
        {
            return;
        }
        
        
    }
    public void GiveUp()
    {
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(3, 3);
        Util.PrintWordLine("결국 경이리는 자신의 빚을 감당하지 못하고");
        Console.SetCursorPosition(3, 5);
        Util.PrintWordLine("포기를 외치고 말았습니다");
        Console.SetCursorPosition(3, 7);
        Util.PrintWordLine("이후 강제 노역장에 끌려가고 말았고");
        Util.PrintWaiting();
        
        Console.Clear();
        Console.SetCursorPosition(3, 3);
        Util.PrintWordLine("매일 75명의 과제와 Til을 검사하는");
        Console.SetCursorPosition(3, 5);
        Util.PrintWordLine("강도 높은 노동을 하고 있다고 합니다...");
        Util.PrintWaiting();
        GameManager.Instance.GameOver = true;
    }

    public void Victory()
    {
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(3, 3);
        Util.PrintWordLine("도박의 신이 강림한 경이리는");
        Console.SetCursorPosition(3, 5);
        Util.PrintWordLine("모든 빚을 갚을 수 있었지만");
        Console.SetCursorPosition(3, 7);
        Util.PrintWordLine("아직까지 도박에 빠져있다고 합니다...");
        Util.PrintWaiting();
        
        Console.Clear();
        Console.SetCursorPosition(3, 3);
        Util.PrintWordLine("지금까지 플레이해주셔서 감사합니다");
        Console.SetCursorPosition(3, 5);
        Util.PrintWordLine("더 어려운 난이도로 도전해보세요!");
        Util.PrintWaiting();
        GameManager.Instance.GameOver = true;
    }
}