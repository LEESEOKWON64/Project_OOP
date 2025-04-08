namespace Project;

public abstract class Scene
{
    protected ConsoleKey _input;
    public abstract void Render();
    public abstract void Input();
    public abstract void Result();
    public abstract void Update();
}