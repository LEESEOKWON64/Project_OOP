using Project.Places;
using Project.Scenes;

namespace Project;

public class GameManager
{
    private bool _gameOver;
    private Scene _curScene;
    private Scene _titleScene;
    private Intro intro;
    private DifficultyLevel _level;
    public DifficultyLevel Level
    {
        get { return _level; }
        set { _level = value; }
    }
 
    
    private int _debt;
    public int Dept
    {
        get { return _debt; }
        set { _debt = value; }
    }
    
    private Dictionary<string,Place> _places;
    public Dictionary<string, Place> Places
    {
        get { return _places; }
    }
    
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
        Console.CursorVisible = false;
        
        _places = new Dictionary<string, Place>();
        _places.Add("casino", new Casino());
        _places.Add("field", new Field());
        _places.Add("home", new Home());
        _places.Add("lottery", new Lottery());
        _places.Add("smithy", new Smithy());
        
        Player.GetInstance();
        _gameOver = false;
        _curScene = new PlaceScene();
        _titleScene = new TitleScene();

        intro = new();
    }
    public void Run()
    {
        Console.Clear();
        _titleScene.Render();
        _titleScene.Input();
        _titleScene.Result();
        _titleScene.Update();

        Console.Clear();
        intro.Print();
        
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