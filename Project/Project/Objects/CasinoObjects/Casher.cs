using Project.Scenes;

namespace Project.CasinoObjects;

public class ATMObject : GameObject
{
    public ATMObject(Vector2 position)
    {
        _symbol = 'A';
        _color = ConsoleColor.Yellow;
        _position = position;
    } 
    public override void Interact()
    {
        Atm.GetInstance();
        Atm.Instance.Talk();
    }
}