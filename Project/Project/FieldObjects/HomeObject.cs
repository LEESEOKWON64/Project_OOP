namespace Project;

public class HomeObject : GameObject
{
    public HomeObject(Vector2 position)
    {
        _symbol = 'H';
        _color = ConsoleColor.Cyan;
        _position = position;
    }
    
    public override void Interact()
    {
        Util.FieldTriangle("집","home");
        Player.Instance.SetPosition(new Vector2(6,6));
    }
}