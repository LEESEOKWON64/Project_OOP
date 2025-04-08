using Project.Places;

namespace Project;

public class Player
{
    private string _name;
    private GameObject _obj;
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
        _obj.Symbol = 'P';
        _obj.Color = ConsoleColor.White;
        _weoponInven = new Inventory<Weopon>();
        _coinInven = new Inventory<Coin>();
        _currentPlace = new Home();
    }

    public void Move(ConsoleKey input)
    {
        Vector2 nextPos = Position;
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
        Console.Write(_currentPlace.Map[_position.y, _position.x]);
    }
}