namespace Project.CasinoObjects;

public class CasherObject : GameObject
{
    public CasherObject(Vector2 position)
    {
        _symbol = 'C';
        _color = ConsoleColor.Yellow;
        _position = position;
    } 
    public override void Interact()
    {
        
    }
}