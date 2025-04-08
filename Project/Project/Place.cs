namespace Project;

public abstract class Place : IInteractable
{
    private char _symbol;
    public char Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }
    private ConsoleColor _color;
    public ConsoleColor Color
    {
        get { return _color; }
        set { _color = value; }
    }
    private char[,] _map;
    public char[,] Map
    {
        get { return _map; }
        set { _map = value; }
    }

    public abstract void Interact();
}