namespace Project;

public class NPC : IInteractable
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
    
    public void Interact()
    {
        // Say();
    }
}