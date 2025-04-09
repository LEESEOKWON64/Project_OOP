using Project.Scenes;

namespace Project.SmithyObjects;

public class BlackSmithObject : GameObject
{
    public BlackSmithObject(Vector2 position)
    {
        _symbol = 'S';
        _color = ConsoleColor.DarkGray;
        _position = position;
    }
    public override void Interact()
    {
        BlackSmith.GetInstance();
        BlackSmith.Instance.Talk();
    }
}