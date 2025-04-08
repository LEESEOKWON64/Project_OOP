namespace Project.HomeObjects;

public class LoverObject : GameObject
{
    public LoverObject(Vector2 position)
    {
        _symbol = 'L';
        _color = ConsoleColor.Magenta;
        _position = position;
    }
    public override void Interact()
    {
        
    }
}