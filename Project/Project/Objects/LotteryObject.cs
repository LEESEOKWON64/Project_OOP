namespace Project;

public class LotteryObject : GameObject
{
    public LotteryObject(Vector2 position)
    {
        _symbol = 'L';
        _color = ConsoleColor.DarkRed;
        _position = position;
    }
    
    public override void Interact()
    {
        Util.FieldTriangle("복권방","lottery");
    }
}