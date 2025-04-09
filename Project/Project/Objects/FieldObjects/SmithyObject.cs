namespace Project;

public class SmithyObject : GameObject
{
    public SmithyObject(Vector2 position)
    {
        _symbol = 'S';
        _color = ConsoleColor.DarkBlue;
        _position = position;
    }

    public override void Interact()
    {
        Util.FieldTriangle("대장간","smithy");
        if (Player.Instance.NextPlace != Player.Instance.CurrentPlace)
        {
            Player.Instance.SetPosition(new Vector2(32, 7));
        }
        Player.Instance.CurrentPlace = Player.Instance.NextPlace;
    }
}