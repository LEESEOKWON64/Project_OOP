namespace Project;

public class GameManager
{
    private bool _gameOver;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    private GameManager()
    {
        _gameOver = false;
    }
    

    public void Run()
    {
        while (!_gameOver)
        {
            
        }
    }
    
    public void End(){}
    
}