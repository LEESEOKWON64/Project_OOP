using System.Resources;
using Project.Places;
using Project.Scenes;

namespace Project;

public class GameManager
{
    private bool _gameOver;
    public bool GameOver
    {
        get => _gameOver;
        set => _gameOver = value;
    }
    private Scene _curScene;
    private Scene _titleScene;
    private char[,] _screen;
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
    
    public void PrintScreen()
    {
        for (int i = 0; i < _screen.GetLength(0); i++)
        {
            for (int j = 0; j < _screen.GetLength(1); j++)
            {
                Console.Write(_screen[i,j]);
            }
            Console.WriteLine();
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
        
        _screen = new char[16, 50];
        for (int i = 0; i < _screen.GetLength(0); i++)
        {
            for (int j = 0; j < _screen.GetLength(1); j++)
            {
                if (i == 0 || i == _screen.GetLength(0) - 1)
                {
                    if (i == 0 && j == 0) _screen[i, j] = '┌';
                    else if(i == 0 && j == _screen.GetLength(1) - 1) _screen[i, j] = '┐';
                    else if(i == _screen.GetLength(0) - 1 && j == 0) _screen[i, j] = '└';
                    else if(i == _screen.GetLength(0) - 1 && j == _screen.GetLength(1) - 1) _screen[i, j] = '┘';
                    else
                    {
                        _screen[i, j] = '─';
                    }
                }
                else if (i == 10)
                {
                    if (i == 10 && j == 0) _screen[i, j] = '├';
                    else if(i == 10 && j == _screen.GetLength(1) - 1) _screen[i, j] = '┤';
                    else
                    {
                        _screen[i, j] = '─';
                    }
                } 
                else if (j == 0 || j == _screen.GetLength(1) - 1)
                {
                    _screen[i, j] = '│';
                }
                else
                {
                    _screen[i, j] = ' ';
                }
            }
        }

        _debt = 1000000;
        intro = new();
    }
    public void Run()
    {
        /*Console.Clear();
        _titleScene.Render();
        _titleScene.Input();
        _titleScene.Result();
        _titleScene.Update();

        Console.Clear();
        intro.Print();*/
        
        while (!_gameOver)
        {
            Console.Clear();
            _curScene.Render();
            _curScene.Input();
            _curScene.Result();
            _curScene.Update();
            if (_debt <= 0)
            {
                Player.Instance.Victory();
            }
        }
    }

    public void End()
    {
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(2,11);
        Util.PrintWordLine("여러분!");
        Console.SetCursorPosition(2,12);
        Util.PrintWordLine("도박은 정신건강에 정말 해로워요!");
        Console.SetCursorPosition(2,13);
        Util.PrintWordLine("플레이어 여러분도 돈을 벌려는 도박보다는");
        Console.SetCursorPosition(2,14);
        Util.PrintWordLine("즐기는 도박을 해요!");
        Util.PrintWaiting();
    }
    
}