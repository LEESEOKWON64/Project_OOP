using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace Project.Scenes;

public class Creditor
{
    private int _bank;
    private int[] _winningNums;
    private Stack<string> _script;
    private int[] _debtArr;

    private static Creditor instance;
    public static Creditor Instance
    {
        get { return instance; }
    }

    private Creditor()
    {
        _bank = 0;
        _winningNums = new int[6];
        _script = new Stack<string>();
        _debtArr = new int[7];
        for (int i = 0; i < _debtArr.Length; i++)
        {
            _debtArr[i] = 0;
        }
    }

    public static Creditor GetInstance()
    {
        if(instance == null)
        {
            instance = new Creditor();
        }
        return instance;
    }

    public void Talk()
    {
        _script.Push("main");

        while (_script.Count > 0)
        {
            Console.Clear();
            string curScript = _script.Peek();
            switch (curScript)
            {
                case "main":
                    Main();
                    break;
                case "lottery":
                    Lottery();
                    break;
                case "buylottery":
                    BuyLottery();
                    break;
                case "result":
                    Result();
                    break;
                case "fulfill":
                    Fulfill();
                    break;
                case "loan":
                    Loan();
                    break;
            }
        }
    }

    private void Main()
    {
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("돈을 갚으러 온건가?");
        Util.PrintWaiting();
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1,11, ref decision,"그렇습니다","조,조금만 시간을 더..!","복권을 보러왔다","추가 대출");
        if (decision == 11)
        {
            _script.Push("fulfill");
        }
        else if(decision == 12)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine("[유니]");
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("에잉 쯧");
            Util.PrintWaiting();
            _script.Pop();
        }
        else if (decision == 13)
        {
            _script.Push("lottery");
        }
        else
        {
            _script.Push("loan");
        }

    }

    private void Lottery()
    {
        
    }

    private void BuyLottery()
    {
        
    }

    private void Result()
    {
        
    }

    private void Fulfill()
    {
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine($"[현재 남은 빚 : {GameManager.Instance.Dept}");
        Util.PrintSideTriangleForNum(3, 12, ref decision, _debtArr);
        if (TransPay() > Player.Instance.Money)
        {
            ResetPay();
            return;
        }
        else
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"{TransPay()}돈을 갚았습니다");
            Player.Instance.Money -= TransPay();
            GameManager.Instance.Dept -= TransPay();
            Util.PrintWordLine($"남은 빚은 {GameManager.Instance.Dept}돈 입니다");
        }
    }

    private int TransPay()
    {
        int pay = 0;
        
        for (int i = 0; i < _debtArr.Length; i++)
        {
            int count = 6-i;
            while (count!=0)
            {
                _debtArr[i] *= 10;
                count -= 1;
            }
            pay += _debtArr[i];
        }
        return pay;
    }

    private int[] ResetPay()
    {
        for (int i = 0; i < _debtArr.Length; i++)
        {
            _debtArr[i] = 0;
        }

        return _debtArr;
    }
    private void Loan()
    {
        
    }
    
    private int[] ResetWinningNums()
    {
        Random rnd = new Random();
        int num;
        for (int i = 0; i < _winningNums.Length; i++)
        {
            while (_winningNums.Length == i)
            {
                num = rnd.Next(0, 10);
                if (!_winningNums.Contains(num))
                {
                    _winningNums[i] = num;
                }
            }
        }
        return _winningNums;
    }

    private int CheckLottery(LotteryTicket ticket)
    {
        int count = 0;
        for (int i = 0; i < ticket.Numbers.Length; i++)
        {
            if (_winningNums.Contains(ticket.Numbers[i]))
            {
                count++;
            }
        }
        return count;
    }

    private float LotteryResult(int count)
    {
        float rate = (count) switch
        {
            2 => 1,
            3 => 2,
            4 => 4,
            5 => 10,
            6 => 150,
            _ => 0
        };
        return rate;
    }

    private void ReduceDebt(int amount,int left, int right)
    {
        int decision = 0;
        if (Player.Instance.Money - amount < 300_000)
        {
            Util.PrintWordLine("채무 이행시 너무 적은 금액이 남아");
            Util.PrintWordLine("플레이에 어려움이 있을 수 있습니다.");
            Util.PrintWordLine("정말로 납부하시겠습니까?");
            Util.PrintSideTriangle(left,right,ref decision,"납부한다","납부하지 않겠다");
            if (decision == left + 1)
            {
                GameManager.Instance.Dept -= amount;
                Player.Instance.Money -= amount;
            }
            else
            {
                return;
            }
        }
        else
        {
            GameManager.Instance.Dept -= amount;
            Player.Instance.Money -= amount;
        }
        
    }

    private void SaveMoney(int amount)
    {
        if (_bank + amount < 100_000_000)
        {
            _bank += amount;
            Player.Instance.Money -= amount;
        }
        else
        {
            Util.PrintWordLine("더 이상 저금할 수 없습니다.");
        }
    }

    private void WithdrawMoney(int amount)
    {
        if (_bank - amount < 0)
        {
            Util.PrintWordLine("저금통의 바닥까지 긁어봤지만");
            Util.PrintWordLine("그 정도의 돈은 들어있지않았습니다");
        }
        else
        {
            _bank -= amount;
            Player.Instance.Money += amount;
        }
    }
}