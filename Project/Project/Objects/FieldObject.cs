namespace Project;

public class FieldObject : GameObject
{
    public FieldObject(Vector2 position)
    {
        _symbol = 'F';
        _color = ConsoleColor.DarkGreen;
        _position = position;
    }
    
    public override void Interact()
    {
        
    }
}