using Project.Scenes;

namespace Project;

public class GameManager
{
    private bool _gameOver;
    private Scene _curScene;
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private GameManager()
    { }

    public static void GetInstance()
    {
        if (_instance == null)
        {
            GameManager._instance = new GameManager();
        }
    }

    public void Start()
    {
        _gameOver = false;
        _curScene = new FieldScene();
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