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
        Player.Instance.CurrentPlace = GameManager.Instance.Places["lottery"];
    }
}