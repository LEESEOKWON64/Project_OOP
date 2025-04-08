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
        Player.Instance.CurrentPlace = GameManager.Instance.Places["casino"];
    }
}