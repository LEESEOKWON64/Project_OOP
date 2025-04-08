using Project.Places;

namespace Project;

public class Player
{
    private string _name;
    private char _symbol;
    private ConsoleColor _color;
    private Inventory<Weopon> _weoponInven;
    private Inventory<Coin> _coinInven;
    private Place _currentPlace;
    public Place CurrentPlace
    {
        get { return _currentPlace; }
        set { _currentPlace = value; }
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
        _weoponInven = new Inventory<Weopon>();
        _coinInven = new Inventory<Coin>();
        _currentPlace = GameManager.Instance.Places["field"];
        _position = new Vector2(6,3);
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
        if (_currentPlace.Map[nextPos.y, nextPos.x] == '#')
        {
            _position = nextPos;
        }
    }
    

    public void Print()
    {
        Console.SetCursorPosition(_position.x, _position.y);
        Console.ForegroundColor = _color;
        Console.WriteLine(_symbol);
        Console.ResetColor();
    }
}