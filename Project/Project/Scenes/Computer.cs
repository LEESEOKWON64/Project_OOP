using System.Reflection.Metadata.Ecma335;

namespace Project.Scenes;

public class Computer
{
    public Coin[] _coins { get; private set; }
    private Stack<string> _menu;

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

        for (int i = 0; i < _coins.Length; i++)
        {
            _coins[i].SetPrice();
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
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("컴퓨터의 전원을 켭니까?",ConsoleColor.White,30 );
        Util.PrintTriangle(1,12, ref decision, out ConsoleKey newInput,"컴퓨터를 켠다","그만둔다");
        
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
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1,11, ref decision, out ConsoleKey newInput, "가상화폐 거래","컴퓨터 종료");

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
        GameManager.Instance.PrintScreen();
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
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1,11,ref decision, out ConsoleKey newInput,"코인 거래","시세 확인","프로그램 종료");

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
        
        int decision1 = 3;
        int decision2 = 4;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(38,1);
        Console.Write($"{Player.Instance.Money}돈");
        Util.PrintSideTriangle(2, 1, ref decision1,"구입한다", "매각한다", "그만둔다");

        if (decision1 == 3)
        {
            Util.PrintTriangle(3, 4, ref decision2, out ConsoleKey newInput,
                                     $"{_coins[0].Name.PadRight(3)}{_coins[0].Price.ToString().PadLeft(10)}", 
                                                   $"{_coins[1].Name.PadRight(3)}{_coins[1].Price.ToString().PadLeft(10)}", 
                                                   $"{_coins[2].Name.PadRight(3)}{_coins[2].Price.ToString().PadLeft(10)}","그만둔다");
            if (newInput == ConsoleKey.Escape) return;
            if (decision2 == 7) return;
            Console.SetCursorPosition(3,8);
            Util.PrintWordLine("몇 개를 구매하시겠습니까?");
            Console.SetCursorPosition(35,8);
            if (decision2 == 4)
            {
                Util.PrintCount("buy",_coins[0], out int num);
                Console.SetCursorPosition(3,12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[0].Name}을 {num}개를 구매하였습니다!");
                BuyCoin(0, num);
            }
            else if (decision2 == 5)
            {
                Util.PrintCount("buy",_coins[1], out int num);
                Console.SetCursorPosition(3,12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[1].Name}을 {num}개를 구매하였습니다!");
                BuyCoin(1, num);
            }
            else if (decision2 == 6)
            {
                Util.PrintCount("buy",_coins[2], out int num);
                Console.SetCursorPosition(3,12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[2].Name}을 {num}개를 구매하였습니다!");
                BuyCoin(2, num);
            }
            Util.PrintWaiting();
        }
        else if(decision1 == 13)
        {
            Util.PrintTriangle(3, 4, ref decision2, out ConsoleKey newInput,
                                                    $"{_coins[0].Name.PadRight(3)}{_coins[0].count.ToString().PadLeft(10)}", 
                                                                  $"{_coins[1].Name.PadRight(3)}{_coins[1].count.ToString().PadLeft(10)}", 
                                                                  $"{_coins[2].Name.PadRight(3)}{_coins[2].count.ToString().PadLeft(10)}","그만둔다");
            if (newInput == ConsoleKey.Escape) return;
            if (decision2 == 7) return;
            
            Console.SetCursorPosition(3,8);
            Util.PrintWordLine("몇 개를 판매하시겠습니까?");
            Console.SetCursorPosition(35,8);
            if (decision2 == 4)
            {
                Util.PrintCount("sell",_coins[0], out int num);
                Console.SetCursorPosition(3,12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[0].Name}을 {num}개를 판매하였습니다!");
                SellCoin(0, num);
            }
            else if (decision2 == 5)
            {
                Util.PrintCount("sell",_coins[1], out int num);
                Console.SetCursorPosition(3,12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[1].Name}을 {num}개를 판매하였습니다!");
                SellCoin(1, num);
            }
            else if (decision2 == 6)
            {
                Util.PrintCount("sell", _coins[2], out int num);
                Console.SetCursorPosition(3, 12);
                if (num == 0) return;
                Util.PrintWordLine($"{_coins[2].Name}을 {num}개를 판매하였습니다!");
                SellCoin(2, num);
            }
            Util.PrintWaiting();
        }
        else
        {
            _menu.Pop();
        }
        
    }
    
    private void BuyCoin(int index,int quantity)
    {
        _coins[index].count += quantity;
        Player.Instance.Money -= _coins[index].Price * quantity;
    }

    private void SellCoin(int index, int quantity)
    {
        if (_coins[index].count < quantity) return;
            
        _coins[index].count -= quantity;
        Player.Instance.Money += _coins[index].Price * quantity;
    }
    
    private void GoingRateMenu()
    {
        int decision = 11;
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1,11,ref decision,out ConsoleKey newInput, 
            $"{_coins[0].Name}[{_coins[0].NickName}]",
                          $"{_coins[1].Name}[{_coins[1].NickName}]",
                          $"{_coins[2].Name}[{_coins[2].NickName}]");
        if (newInput == ConsoleKey.Escape) return;
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        if (decision == 11)
        {
            int price = _coins[0].SetPrice(out int change);
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[0].NickName}/{_coins[0].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {price}돈 = 1{_coins[0].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
            Util.PrintWaiting();
            if (price < 200)
            {
                Console.Clear();
                Console.SetCursorPosition(1,11);
                Util.PrintWordLine("[해당 코인은 상장 폐지되었습니다]");
                Console.SetCursorPosition(1,12);
                Util.PrintWordLine("[보유하고 있던 코인이 전부 소멸합니다]");
                _coins[0].count = 0;
            }
        }
        else if(decision == 12)
        {
            int price = _coins[1].SetPrice(out int change);
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[1].NickName}/{_coins[1].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {price}돈 = 1{_coins[1].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
            Util.PrintWaiting();
            if (price < 200)
            {
                Console.Clear();
                Console.SetCursorPosition(1,11);
                Util.PrintWordLine("[해당 코인은 상장 폐지되었습니다]");
                Console.SetCursorPosition(1,12);
                Util.PrintWordLine("[보유하고 있던 코인이 전부 소멸합니다]");
                _coins[1].count = 0;
            }
        }
        else
        {
            int price = _coins[2].SetPrice(out int change);
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"<{_coins[2].NickName}/{_coins[2].Name}>",ConsoleColor.White,30);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[현재 가격 : {price}돈 = 1{_coins[2].Name}]",ConsoleColor.White,30);
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[최근 변동가 : {change}]",ConsoleColor.White,30);
            Util.PrintWaiting();
            if (price < 200)
            {
                Console.Clear();
                Console.SetCursorPosition(1,11);
                Util.PrintWordLine("[해당 코인은 상장 폐지되었습니다]");
                Console.SetCursorPosition(1,12);
                Util.PrintWordLine("[보유하고 있던 코인이 전부 소멸합니다]");
                _coins[2].count = 0;
            }
        }
        _menu.Pop();
    }
    
}