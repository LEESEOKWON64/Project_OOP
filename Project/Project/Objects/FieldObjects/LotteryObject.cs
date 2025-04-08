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
        if (Player.Instance.NextPlace != Player.Instance.CurrentPlace)
        {
            Player.Instance.SetPosition(new Vector2(6, 6));
        }
        Player.Instance.CurrentPlace = Player.Instance.NextPlace;
    }
}