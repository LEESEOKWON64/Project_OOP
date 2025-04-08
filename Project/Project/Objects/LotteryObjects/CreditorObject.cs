namespace Project.LotteryObjects;

public class CreditorObject : GameObject
{
    public CreditorObject(Vector2 position)
    {
        _symbol = 'C';
        _color = ConsoleColor.White;
        _position = position;
    }
    public override void Interact()
    {
        
    }
}