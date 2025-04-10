using Project.Scenes;

namespace Project.CasinoObjects;

public class SlotMachineObject : GameObject
{
    public SlotMachineObject(Vector2 position)
    {
        _symbol = 'M';
        _color = ConsoleColor.DarkRed;
        _position = position;
    } 
   
    public override void Interact()
    {
        SlotMachine.GetInstance();
        SlotMachine.Instance.Talk();
    }
}