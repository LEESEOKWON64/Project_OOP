using System.ComponentModel.Design;
using System.Net.WebSockets;
using System.Reflection.Metadata;

namespace Project.Scenes;

public class Creditor
{
    private int _bank;
    private Stack<string> _script;
    private int[] _winningNums;
    private int[] _debtArr;
    private LotteryTicket _lottery;

    private static Creditor instance;
    public static Creditor Instance
    {
        get { return instance; }
    }

    private Creditor()
    {
        _bank = 0;
        _script = new Stack<string>();
        _winningNums = new int[6];
        _debtArr = new int[7];
        _lottery = new LotteryTicket();
        for (int i = 0; i < _debtArr.Length; i++)
        {
            _debtArr[i] = 0;
        }
        for (int i = 0; i < _lottery.Numbers.Length; i++)
        {
            _winningNums[i] = 0;
            _lottery.Numbers[i] = 0;
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
                case "buyLottery":
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
        int decision = 11;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("돈을 갚으러 온건가?");
        Util.PrintWaiting();
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1,11, ref decision, out ConsoleKey newInput,
            "그렇습니다","조,조금만 시간을 더..!","복권을 보러왔다","추가 대출");
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
        int decision = 11;
        GameManager.Instance.PrintScreen();
        Util.PrintTriangle(1, 11, ref decision, out ConsoleKey newInput, "복원 구매", "당첨 확인", "뒤로 가기");
        if (decision == 11)
        {
            _script.Push("buyLottery");
        }
        else if(decision == 12)
        {
            _script.Push("result");
        }
        else
        {
            _script.Pop();
        }
    }

    private void BuyLottery()
    {
        int decision = 13;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("복권은 한 번에 하나 밖에 구매할 수 없네");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("한 장에 30000돈이니 신중하게 결정하게");
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("어떤 복권을 구매하겠나?");
        Util.PrintTriangle(1, 13, ref decision, out ConsoleKey newInput,"자동 번호 입력", "수동 번호 입력");
        if (newInput == ConsoleKey.Escape) return;

        if (decision == 14)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            Util.PrintWordLine("[복권 번호를 입력해주세요]");
            Util.PrintSideTriangleForNum(3, 12, ref decision, _lottery.Numbers);
        }
        else
        {
            _lottery.SetAutoNumbers();
        }
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[복권을 구매하였습니다]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("[복권 번호]");
        Console.SetCursorPosition(1,13);
        PrintNumbers(_lottery.Numbers);
        Util.PrintWaiting();

        Player.Instance.Money -= 30000;
        _script.Pop();
    }

    private void Result()
    {
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("어디 구매한 복권 좀 줘봐");
        Util.PrintWaiting();

        Console.Clear();
        GameManager.Instance.PrintScreen();
        if (_lottery.Numbers.Contains(0))
        {
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine("[유니]");
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("뭐야 아직 구매를 안했구먼? 허허");
            Util.PrintWaiting();
            _script.Pop();
            return;
        }
        
        int[] winNum = ResetWinningNums();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[당첨 번호]");
        Console.SetCursorPosition(1,12);
        PrintNumbers(winNum);
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("[구매한 복권 번호]");
        Console.SetCursorPosition(1,14);
        PrintNumbers(_lottery.Numbers);
        Util.PrintWaiting();

        int correct = CheckLottery(_lottery.Numbers, winNum);
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWord("어디보자...  ");
        Util.PrintWordLine($"{correct}개를 맞췄구만?");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("자네 운이 좋구만 여기 돈 받아가게");
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(3,12);
        Util.PrintWordLine($"[{LotteryResult(correct) * 30_000}돈을 얻었습니다!]");
        Util.PrintWaiting();

        Player.Instance.Money += (int)(LotteryResult(CheckLottery(winNum, _lottery.Numbers)) * 30_000);
        ResetArr(_lottery.Numbers);
        _script.Pop();
    }
    
    private void Loan()
    {
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[유니]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine("여기서 추가 대출을 하겠다고?");
        Console.SetCursorPosition(1,13);
        Util.PrintWordLine("간이 큰 건지 겁이 없는 건지...");
        Util.PrintWaiting();
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine($"[현재 남은 빚 : {GameManager.Instance.Dept}]");
        Util.PrintSideTriangleForNum(3, 12, ref decision, _debtArr);
        
        int pay = TransPay();
        Player.Instance.Money += pay;
        GameManager.Instance.Dept += pay;
        
        Console.Clear();
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine($"[{pay}돈을 추가로 빌렸습니다]");
        Console.SetCursorPosition(1,12);
        Util.PrintWordLine($"[남은 빚은 {GameManager.Instance.Dept}돈 입니다]");
        Util.PrintWaiting();
        ResetArr(_debtArr);
        _script.Pop();
    }

    private void Fulfill()
    {
        int decision = 0;
        GameManager.Instance.PrintScreen();
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine($"[현재 남은 빚 : {GameManager.Instance.Dept}");
        Util.PrintSideTriangleForNum(3, 12, ref decision, _debtArr);
        int pay = TransPay();
        if (pay > Player.Instance.Money)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("[보유하고 있는 돈보다 많이 입력했습니다]");
            Util.PrintWaiting();
            ResetArr(_debtArr);
            return;
        }
        else
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Player.Instance.Money -= pay;
            GameManager.Instance.Dept -= pay;
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine($"[{pay}돈을 갚았습니다]");
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine($"[남은 빚은 {GameManager.Instance.Dept}돈 입니다]");
            Util.PrintWaiting();
            ResetArr(_debtArr);
            _script.Pop();
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

    private int[] ResetArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = 0;
        }

        return arr;
    }
    
    
    private int[] ResetWinningNums()
    {
        Random rnd = new Random();
        int num;
        for (int i = 0; i < _winningNums.Length; i++)
        {
            while (_winningNums[i] == 0)
            {
                num = rnd.Next(1, 10);
                if (!_winningNums.Contains(num))
                {
                    _winningNums[i] = num;
                }
            }
        }
        return _winningNums;
    }

    private int CheckLottery(int[] left, int[] right)
    {
        int count = 0;
        for (int i = 0; i < right.Length; i++)
        {
            if (left.Contains(right[i]))
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

    private void PrintNumbers(int[] lottery)
    {
        Util.PrintWord("[  ");
        for (int i = 0; i < lottery.Length; i++)
        {
            Util.PrintWord($"{lottery[i]}");
            Console.Write("  ");
        }
        Util.PrintWordLine("]");
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