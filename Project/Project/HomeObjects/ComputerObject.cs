namespace Project.HomeObjects;

public class ComputerObject : GameObject
{
    public ComputerObject(Vector2 position)
    {
        _symbol = 'C';
        _color = ConsoleColor.Gray;
        _position = position;
    }
    public override void Interact()
    {
        
    }
}