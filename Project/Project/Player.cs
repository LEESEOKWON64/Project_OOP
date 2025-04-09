using Project.Places;

namespace Project;

public class Player
{
    private string _name;
    private char _symbol;
    private ConsoleColor _color;
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
        _currentPlace = GameManager.Instance.Places["casino"];
        _prevPlace = GameManager.Instance.Places["casino"];
        _nextPlace = GameManager.Instance.Places["casino"];
        _position = new Vector2(32,7);
        Weopon = new List<Weopon>();
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
}