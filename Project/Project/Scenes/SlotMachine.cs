namespace Project.Scenes;

public class SlotMachine
{
    private Stack<string> _script;
    private char[] _left;
    private char[] _mid;
    private char[] _right;
    private int _level;
    private int _betting;
    
    
    private static SlotMachine instance;
    public static SlotMachine Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private SlotMachine()
    {
        _script = new Stack<string>();
        _left = new char[24]
        {
            '◆', '◆', '●', '●', '♥', '♥', 
            '♣', '♣', '★', '★', '7', '7', 
            '◆', '◆', '●', '●', '♥', '♥', 
            '♣', '♣', '★', '★', '7', '7' 
        };
        _mid = new char[24]
        {
            '◆', '●', '♥', '♣', '★', '7', 
            '◆', '●', '♥', '♣', '★', '7', 
            '◆', '●', '♥', '♣', '★', '7', 
            '◆', '●', '♥', '♣', '★', '7'
        };
        _right = new char[24]
        {
            '◆', '●', '♥', '♣', '★', '7',
            '◆', '●', '♥', '♣', '★', '◆',
            '●', '♥', '♣', '◆', '●', '♥',
            '◆', '●', '◆', '◆', '●', '♥'
        };
    }
    
    public static SlotMachine GetInstance()
    {
        if (instance == null)
        {
            instance = new SlotMachine();
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
                case "level":
                    Level();
                    break;
                case "play":
                    Play();
                    break;
                    
            }
        }
    }

    private void Main()
    {
        int decision1 = 12;
        int decision2 = 12;
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[슬롯 머신 레볼루션 - 대박을 노려라]",ConsoleColor.White,20);
        Util.PrintTriangle(1, 12, ref decision1, out ConsoleKey newInput, "동전을 넣는다", "그만둔다");
        if (decision1 == 12)
        {
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Util.PrintSideTriangleForNum(3, 12, ref decision2, Player.Instance.bet);
            _betting = Util.Transbet();
            if (_betting > Player.Instance.Money)
            {
                Console.Clear();
                GameManager.Instance.PrintScreen();
                Console.SetCursorPosition(1,12);
                Util.PrintWordLine("[보유하고 있는 돈보다 많이 입력했습니다]");
                Util.PrintWaiting();
                Util.ResetArr(Player.Instance.bet);
                return;
            }
            else
            {
                Console.Clear();
                GameManager.Instance.PrintScreen();
                Console.SetCursorPosition(1,12);
                Util.PrintWordLine($"[{_betting}돈을 베팅합니다]");
                Player.Instance.Money -= _betting;
                Util.PrintWaiting();
                Util.ResetArr(Player.Instance.bet);
            }
            _script.Push("level");
        }
        else
        {
            _script.Pop();
        }
    }
    private void Level()
    {
        int decision = 12;
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[난이도 선택]",ConsoleColor.White,20);
        Util.PrintTriangle(1, 12, ref decision, out ConsoleKey newInput, "초심자 - 배율 : x 1", "숙련자 - 배율 : x 2", $"{"신".PadLeft(5)} - 배율 : x 5" );
        if (decision == 12)
        {
            _level = 500;
        }
        else if(decision == 13)
        {
            _level = 300;
        }
        else
        {
            _level = 100;
        }
        _script.Push("play");
    }

    private void Play()
    {
        int left = 20;
        int right = 5;
        Console.SetCursorPosition(1,11);
        Util.PrintWordLine("[룰렛을 돌려주세요]",ConsoleColor.White,20);
        
        PrintSlot(left, right, out int count1, out int count2, out int count3);

        if (_left[count1 % 24] == _mid[count2 % 24] && _mid[count2 % 24] == _right[count3 % 24])
        {
            int winning = (int)(Winnings() * CalculateRate(count2 % 24));
            Player.Instance.Money += winning;
            
            Console.SetCursorPosition(23,7);
            Util.PrintWordLine("당첨!!");
            Util.PrintWaiting();
            
            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1,11);
            Util.PrintWordLine("[슬롯 머신 레볼루션 - 대박을 노려라]");
            Console.SetCursorPosition(1,12);
            Util.PrintWordLine("당첨을 축하합니다");
            Console.SetCursorPosition(1,13);
            Util.PrintWordLine($"당첨금 {winning}돈 입니다");
            Util.PrintWaiting();
        }
        else
        {
            Console.SetCursorPosition(23, 7);
            Util.PrintWordLine("실패..");
            Util.PrintWaiting();

            Console.Clear();
            GameManager.Instance.PrintScreen();
            Console.SetCursorPosition(1, 11);
            Util.PrintWordLine("[슬롯 머신 레볼루션 - 대박을 노려라]");
            Console.SetCursorPosition(1, 12);
            Util.PrintWordLine("정말 아쉽습니다");
            Console.SetCursorPosition(1, 13);
            Util.PrintWordLine("다음 기회를 도전하세요");
            Util.PrintWaiting();
        }
        _script.Pop();
        _script.Pop();
    }

    private float CalculateRate(int index)
    {
        float rate = (_mid[index]) switch
        {
            '\u25c6' => 1.5f,
            '\u25cf' => 2,
            '\u2665' => 3,
            '\u2663' => 5,
            '\u2605' => 7,
            '7' => 14,
            _ => 1
        };
        return rate;
    } 

    private int Winnings()
    {
        if (_level == 500)
        {
            return _betting;
        }
        else if (_level == 300)
        {
            return _betting * 2;
        }
        else
        {
            return _betting * 5;
        }
    }
    
    private void PrintSlot(int left, int right, out int count1,out int count2,out int count3)
    {
        ConsoleKey input = Console.ReadKey().Key;
        int count = -1;
        while (!Console.KeyAvailable)
        {
            for (int i = 0; i < _right.Length; i++)
            {
                if (Console.KeyAvailable) break;

                Console.SetCursorPosition(left, right);
                Console.Write(_left[i]);
                Console.SetCursorPosition(left+5, right);
                Console.Write(_mid[i]);
                Console.SetCursorPosition(left + 10, right);
                Console.Write(_right[i]);
                Thread.Sleep(_level);
                Console.SetCursorPosition(left, right);
                Console.Write(" ");      
                Console.SetCursorPosition(left + 5, right);
                Console.Write(" ");
                Console.SetCursorPosition(left + 10, right);
                Console.Write(" ");
                count += 1;
            }
        }
        Console.SetCursorPosition(left, right);
        Console.Write(_left[count % 24]);
        count1 = count;
        input = Console.ReadKey().Key;

        while (!Console.KeyAvailable)
        {
            for (int i = 0; i < _right.Length; i++)
            {
                if (Console.KeyAvailable) break;

                Console.SetCursorPosition(left + 5, right);
                Console.Write(_mid[i]);
                Console.SetCursorPosition(left + 10, right);
                Console.Write(_right[i]);
                Thread.Sleep(_level);
                Console.SetCursorPosition(left + 5, right);
                Console.Write(" ");
                Console.SetCursorPosition(left + 10, right);
                Console.Write(" ");
                count += 1;
            }
        }
        Console.SetCursorPosition(left + 5, right);
        Console.Write(_mid[count % 24]);
        count2 = count;
        input = Console.ReadKey().Key;

        while (!Console.KeyAvailable)
        {
            for (int i = 0; i < _right.Length; i++)
            {
                if (Console.KeyAvailable) break;

                Console.SetCursorPosition(left + 10, right);
                Console.Write(_right[i]);
                Thread.Sleep(_level);
                Console.SetCursorPosition(left + 10, right);
                Console.Write(" ");
                count += 1;
            }
        }
        Console.SetCursorPosition(left + 10, right);
        Console.Write(_right[count % 24]);
        count3 = count;
    }
}