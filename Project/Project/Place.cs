namespace Project;

public abstract class Place
{
    protected string _name;

    public string Name
    {
        get { return _name; }
    }
    
    private char[,] _map;
    public char[,] Map
    {
        get { return _map; }
        set { _map = value; }
    }
    
    protected List<GameObject> _objs;

    public List<GameObject> Objs
    {
        get { return _objs; }
    }

    public Place()
    {
        _objs = new List<GameObject>();
    }


    public void PrintMap()
    {
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                Console.Write(_map[i,j]);
            }
            Console.SetCursorPosition(16,2+i);
        }
    }
}