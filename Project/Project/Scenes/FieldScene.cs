namespace Project.Scenes;

public class PlaceScene : Scene
{
    public override void Render()
    {
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(16,1);
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
        for (int i = 0; i < Player.Instance.CurrentPlace.Objs.Count; i++)
        {
            if (Player.Instance.CurrentPlace.Objs[i].Position == Player.Instance.Position)
            {
                Player.Instance.CurrentPlace.Objs[i].Interact();
                break;
            }
        }
    }

    public override void Update()
    {
        
    }
}