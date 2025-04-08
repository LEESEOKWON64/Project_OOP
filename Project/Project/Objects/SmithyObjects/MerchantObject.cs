namespace Project.SmithyObjects;

public class MerchantObject : GameObject
{
    public MerchantObject(Vector2 position)
    {
        _symbol = 'M';
        _color = ConsoleColor.Yellow;
        _position = position;
    }
    public override void Interact()
    {
        
    }
}