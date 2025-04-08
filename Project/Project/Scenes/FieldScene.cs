namespace Project.Scenes;

public class FieldScene : Scene
{
    public override void Render()
    {
        Player.Instance.CurrentPlace.PrintMap();
        foreach (var obj in Player.Instance.CurrentPlace.Objs)
        {
            obj.Print();
        }
        Player.Instance.Print();
    }

    public override void Input()
    {
        _input = Console.ReadKey(true).Key;
    }

    public override void Result()
    {
        Player.Instance.Move(_input);
    }

    public override void Update()
    {
        
    }
}