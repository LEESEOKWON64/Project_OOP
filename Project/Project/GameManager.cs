using Project.Scenes;

namespace Project;

public class GameManager
{
    private bool _gameOver;
    private Scene _curScene;
    
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private GameManager()
    { }

    public static void GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
    }

    public void Start()
    {
        _gameOver = false;
        _curScene = new FieldScene();
        Player.GetInstance();
    }
    public void Run()
    {
        while (!_gameOver)
        {
            Console.Clear();
            _curScene.Render();
            _curScene.Input();
            _curScene.Result();
            _curScene.Update();
        }
    }
    
    public void End(){}
    
}