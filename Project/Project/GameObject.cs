namespace Project;

public abstract class GameObject : IInteractable
{
    
    protected char _symbol;
    
    public char Symbol
    {
        get { return _symbol; }
        set { _symbol = value; }
    }
    protected ConsoleColor _color;
    public ConsoleColor Color
    {
        get { return _color; }
        set { _color = value; }
    }
    protected Vector2 _position;

    public Vector2 Position
    {
        get { return _position; }
    }
    
    public void Print()
    {
        Console.SetCursorPosition(_position.x, _position.y);
        Console.ForegroundColor = _color;
        Console.WriteLine(_symbol);
        Console.ResetColor();
    }
    
    public abstract void Interact();
}