using Project.Places;

namespace Project;

public class CasinoObject : GameObject
{
    public CasinoObject(Vector2 position)
    {
        _symbol = 'C';
        _color = ConsoleColor.DarkYellow;
        _position = position;
    }
    
    public override void Interact()
    {
        Util.FieldTriangle("카지노","casino");
        if (Player.Instance.NextPlace != Player.Instance.CurrentPlace)
        {
            Player.Instance.SetPosition(new Vector2(32, 7));
        }
        Player.Instance.CurrentPlace = Player.Instance.NextPlace;
    }
}