using System.Xml.Linq;

namespace Project.Scenes;

public class Atm
{
    private Stack<string> _script;
    private int _bank;
    private int[] _input;
    private int _inputInt;
    
    private static Atm instance;
    public static Atm Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private Atm()
    {
        _script = new Stack<string>();
        _bank = 0;
        _input = new int[7]{0,0,0,0,0,0,0};
    }
    
    public static Atm GetInstance()
    {
        if (instance == null)
        {
            instance = new Atm();
        }
        return instance;
    }
    
    public void Talk()
    {
        _script.Push("main");

        while (_script.Count > 0)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            string curScript = _script.Peek();
            switch (curScript)
            {
                case "main":
                    Main();
                    break;
                case "choice":
                    Choice();
                    break;
                case "save":
                    Save();
                    break;
                case "withdraw":
                    Withdraw();
                    break;
            }
        }
    }

    private void Main()
    {
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[구형 ATM기]", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 12);
        Util.PrintWordLine("노는데 돈이 부족하신가요?", ConsoleColor.White, 20);
        Console.SetCursorPosition(1, 13);
        Util.PrintWordLine("지금까지 저축한 돈을 사용해보세요!", ConsoleColor.White, 20);
        Util.PrintWaiting();
        _script.Push("choice");
    }
    private void Choice()
    {
        int decision = 12;
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1, 11);
        Util.PrintWordLine("[구형 ATM기]", ConsoleColor.White, 20);
        Util.PrintTriangle(1, 12, ref decision, out ConsoleKey newInput, "입금하기", "인출하기","그만두기");
        if (decision == 12)
        {
            _script.Push("save");
        }
        else if (decision == 13)
        {
            _script.Push("withdraw");
        }
        else
        {
            _script.Pop();
            _script.Pop();
        }
    }
    
    private void Save()
    {
        int decision = 12;
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(3, 11);
        Util.PrintWordLine($"[현재 가진 돈 : {Player.Instance.Money}]");
        Util.PrintSideTriangleForNum(3, 13, ref decision, _input);
        _inputInt = TransInput();
        if (_inputInt > Player.Instance.Money)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 12);
            Util.PrintWordLine("[보유하고 있는 돈보다 많이 입력했습니다]");
            Util.PrintWaiting();
            Util.ResetArr(_input);
            _script.Pop();
            return;
        }
        else
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            if (_bank + _inputInt > 99_999_999)
            {
                Util.PrintWordLine("더 이상 입금이 불가능합니다", ConsoleColor.White, 20);
                return;
            }
            SaveMoney(_inputInt);
            Util.PrintWordLine("[구형 ATM기]", ConsoleColor.White, 20);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[통장에 {_inputInt}돈을 입금했습니다]");
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[현재 통장 잔고는 {_bank}돈 입니다]");
            Util.PrintWaiting();
            Util.ResetArr(_input);
            _script.Pop();
        }
    }

    private void Withdraw()
    {
        int decision = 12;
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(3, 11);
        Util.PrintWordLine($"[통장 잔고 : {_bank}]");
        Util.PrintSideTriangleForNum(3, 13, ref decision, _input);
        _inputInt = TransInput();
        if (_inputInt > _bank)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            Util.PrintWordLine("통장을 아무리 훑어봐도", ConsoleColor.White, 20);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("이 정도의 돈이 들어있지않습니다", ConsoleColor.White, 20);
            Util.PrintWaiting();
            Util.ResetArr(_input);
            _script.Pop();
        }
        else
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            if (Player.Instance.Money + _inputInt > 9_999_999)
            {
                Util.PrintWordLine("더 이상 출금이 불가능합니다", ConsoleColor.White, 20);
                _script.Pop();
                return;
            }
            WithdrawMoney(_inputInt);
            Util.PrintWordLine("[구형 ATM기]", ConsoleColor.White, 20);
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[통장에서 {_inputInt}돈을 출금했습니다]");
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"[현재 통장 잔고는 {_bank}돈 입니다]");
            Util.PrintWaiting();
            Util.ResetArr(_input);
            _script.Pop();
        }
    }
    
    private void SaveMoney(int amount)
    {
        if (_bank + amount < 100_000_000)
        {
            _bank += amount;
            Player.Instance.Money -= amount;
        }
    }

    private void WithdrawMoney(int amount)
    {
        if (_bank - amount >= 0)
        {
            _bank -= amount;
            Player.Instance.Money += amount;
        }
    }
    
    private int TransInput()
    {
        int pay = 0;
        
        for (int i = 0; i < _input.Length; i++)
        {
            int count = _input.Length - 1 - i;
            while (count!=0)
            {
                _input[i] *= 10;
                count -= 1;
            }
            pay += _input[i];
        }
        return pay;
    }
}