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
        Player.Instance.CurrentPlace = GameManager.Instance.Places["smithy"];
    }
}