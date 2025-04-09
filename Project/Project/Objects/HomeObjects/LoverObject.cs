namespace Project.HomeObjects;

public class LoverObject : GameObject
{
    public LoverObject(Vector2 position)
    {
        _symbol = 'L';
        _color = ConsoleColor.Magenta;
        _position = position;
    }
    public override void Interact()
    {
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[당신의 애인 경아는 매일 광산에서 일을 합니다.]",ConsoleColor.White,30);
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("[죄책감이 드신다면, 빚을 얼른 갚읍시다!]",ConsoleColor.White,30);
        Util.PrintWaiting();
    }
}