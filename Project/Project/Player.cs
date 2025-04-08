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

    private Player()
    {
        _name = "경이리";
        _symbol = 'P';
        _color = ConsoleColor.White;
        _weoponInven = new Inventory<Weopon>();
        _coinInven = new Inventory<Coin>();
        _currentPlace = new Home();
    }

    public void Move()
    {
        
    }

    public void Interact()
    {
        
    }
}