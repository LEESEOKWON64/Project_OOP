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
        Util.FieldTriangle("밖","field");
        if (Player.Instance.NextPlace != Player.Instance.CurrentPlace)
        {
            if(Player.Instance.CurrentPlace.Name == "smithy")
            {
                Player.Instance.SetPosition(new Vector2(24, 7));
            }
            else if(Player.Instance.CurrentPlace.Name == "casino")
            {
                Player.Instance.SetPosition(new Vector2(21, 3));
            }
            else if (Player.Instance.CurrentPlace.Name == "home")
            {
                Player.Instance.SetPosition(new Vector2(18, 5));
            }
            else
            {
                Player.Instance.SetPosition(new Vector2(30, 3));
            }
        }
        Player.Instance.CurrentPlace = Player.Instance.NextPlace;
    }
}