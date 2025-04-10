using Project.Scenes;

namespace Project.CasinoObjects;

public class SnifflingObject : GameObject
{
    public SnifflingObject(Vector2 position)
    {
        _symbol = 'H';
        _color = ConsoleColor.Green;
        _position = position;
    } 
    public override void Interact()
    {
        Sniffling.GetInstance();
        Sniffling.Instance.Talk();
    }
}