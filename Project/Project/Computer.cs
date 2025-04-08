namespace Project.Scenes;

public class Computer
{
    private Coin[] _coins;
    private Stack<string> _menu;
    private char[,] _screen;
    private static Computer instance;

    public static Computer Instance
    {
        get { return instance; }
    }

    private Computer()
    {
        _coins = new Coin[3];
        _menu = new Stack<string>();
        _coins[0] = (new Coin(){Name = "JTC", NickName = "정택코인", count = 0});
        _coins[1] = (new Coin(){Name = "CJ", NickName = "캐시재성", count = 0});
        _coins[2] = (new Coin(){Name = "YVC", NickName = "준헌가상화폐", count = 0});
        
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

    public static void GetIntance()
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
                    StartMenu();
                    break;
                case "deskTop":
                    DestTopMenu();
                    break;
                case "coinIntroMenu":
                    CoinIntroMenu();
                    break; 
                case "coinMenu":
                    CoinMenu();
                    break;
                case "exchange":
                    ExchangeMenu();
                    break;
                case "goingRate":
                    GoingRateMenu();
                    break;
            }
        }
    }

    private void StartMenu()
    {
        PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("컴퓨터의 전원을 켭니까?",ConsoleColor.White,30
            );
        Util.PrintTriangle(1,12,"컴퓨터를 켠다","그만둔다");

        if (Console.GetCursorPosition() == (0, 12))
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
        PrintScreen();
        Util.PrintTriangle(1,11,"가상화폐 거래","컴퓨터 종료");

        if (Console.GetCursorPosition() == (0, 11))
        {
            _menu.Push("coinMenu");
        }
        else 
        {
            _menu.Pop();
            _menu.Pop();
        }
    }

    private void CoinIntroMenu()
    {
        PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("가상화폐 거래소에 오신걸 환영합니다.",ConsoleColor.White,20);
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("환전가는 주기적으로 갱신됩니다.",ConsoleColor.White,20);
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("최소 환전가 200돈 이하가 되면",ConsoleColor.White,20);
        Console.SetCursorPosition(1,14);
        Util.PrintWordLine("상장폐지가 되어 아이템이 전부 폐기됩니다.",ConsoleColor.White,20);
        Console.ReadKey(true);
        _menu.Push("coinMenu");
    }

    private void CoinMenu()
    {
        PrintScreen();
        Util.PrintTriangle(1,11,"코인 거래","시세 확인","프로그램 종료");

        if (Console.GetCursorPosition() == (0, 11))
        {
            _menu.Push("exchange");
        }
        else if(Console.GetCursorPosition() == (0, 12))
        {
            _menu.Push("goingRate");
        }
        else
        {
            _menu.Pop();
            _menu.Pop();
        }
    }

    private void ExchangeMenu()
    {
        
    }

    private void GoingRateMenu()
    {
        PrintScreen();
        Util.PrintTriangle(1,11,$"{_coins[0].Name}[{_coins[0].NickName}]",
            $"{_coins[1].Name}[{_coins[1].NickName}]",
            $"{_coins[2].Name}[{_coins[2].NickName}]");
        Console.Clear();
        PrintScreen();
        if (Console.GetCursorPosition() == (0, 11))
        {
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[0].NickName}/{_coins[0].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {_coins[0].SetPrice(out int change)}돈 = 1{_coins[0].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
        }
        else if(Console.GetCursorPosition() == (0, 12))
        {
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[1].NickName}/{_coins[1].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {_coins[1].SetPrice(out int change)}돈 = 1{_coins[1].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
        }
        else
        {
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[2].NickName}/{_coins[2].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {_coins[2].SetPrice(out int change)}돈 = 1{_coins[2].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
        }
        Console.ReadKey(true);
        _menu.Pop();
    }

}