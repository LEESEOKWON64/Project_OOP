namespace Project.Scenes;

public class Computer
{
    private Inventory<Coin> _coins;
    private Stack<string> _menu;
    private char[,] _screen;
    private static Computer instance;

    public static Computer Instance
    {
        get { return instance; }
    }

    private Computer()
    {
        _coins = new Inventory<Coin>();
        _menu = new Stack<string>();
        
        _screen = new char[16, 30];
        for (int i = 0; i < _screen.GetLength(0); i++)
        {
            for (int j = 0; j < _screen.GetLength(1); j++)
            {
                if (i == 0 || i == _screen.GetLength(0))
                {
                    if (i == 0 && j == 0) _screen[i, j] = '┌';
                    else if(i == 0 && j == _screen.GetLength(1)) _screen[i, j] = '┐';
                    else if(i == _screen.GetLength(0) && j == 0) _screen[i, j] = '└';
                    else if(i == _screen.GetLength(0) && j == _screen.GetLength(1)) _screen[i, j] = '┛';
                    _screen[i, j] = '─';
                }
                else if (j == 0 || j == _screen.GetLength(1) - 1)
                {
                    
                    _screen[i, j] = '│';
                }
                _screen[i, j] = ' ';
            }
        }
    }

    private void PrintScreen()
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

    public void GetIntance()
    {
        if (instance == null)
        {
            instance = new Computer();
        }
    }

    public void Browse()
    {
        _menu.Push("start");
        
        while (_menu.Count > 0)
        {
            Console.Clear();
            string browser = _menu.Peek();
            switch (browser)
            {
                case "start":
                    break;
                case "deskTop":
                    break;
                case "coinMenu":
                    break;
                case "exchange":
                    break;
                case "goingRate":
                    break;

            }
        }
    }

    private void StartMenu()
    {
        
        Util.PrintWordLine("컴퓨터의 전원을 켭니까?");
        Util.PrintTriangle(0,1,"컴퓨터를 켠다","그만둔다");

        if (Console.GetCursorPosition() == (0, 4))
        {
            _menu.Push("deskTop");
        }
        else
        {
            _menu.Pop();
        }
    }

    private void DestTopMenu()
    {
        Util.PrintTriangle(0,1,"가상화폐 거래","컴퓨터 종료");

        if (Console.GetCursorPosition() == (0, 4))
        {
            _menu.Push("deskTop");
        }
        else
        {
            _menu.Pop();
        }
    }
    
    private void CoinMenu(){}
    private void ExchangeMenu(){}
    private void GoingRateMenu(){}

}