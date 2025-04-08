using System.Collections.Specialized;
using System.Threading.Channels;

namespace Project.Scenes;

public class TitleScene : Scene
{
    public override void Render()
    {
        Console.WriteLine("본 게임은 저장과 불러오기가 불가능한 \"게임\"입니다.");
        Console.WriteLine("");
        Util.PrintLine("부디 오락, 게임으로만 즐겨주세요.",0,ConsoleColor.Red);
        Thread.Sleep(3500);
        Console.Clear();
        Util.PrintWordLine("OOP 콘솔 프로젝트가 끝난 뒤 얼마지나지 않은 시점");
        Console.WriteLine("");
        Util.PrintWordLine("경이리는 KY마을에서 \"카지노\"를 발견하게 된다.");
        Console.WriteLine("");
        Util.PrintWordLine("훈련지원금을 받은 경이리는 유흥으로 도박을 하기 시작했고,");
        Console.WriteLine("");
        Util.PrintWord("전재산 ");
        Util.PrintWord("4천만돈",ConsoleColor.Red);
        Util.PrintWordLine("을 잃고");
        Util.PrintWord("3000만 돈",ConsoleColor.Red);
        Util.PrintWordLine("의 빚을 지게 되었다.");
        Console.ReadKey(true);
        Console.Clear();
        Util.PrintWordLine("그렇게 경이리 수중에 남은 돈, 15만원돈...");
        Util.PrintWordLine("이 돈으로 경이리는 기사회생에 나선다!");
        Util.PrintWordLine("도박으로 빚을 갚고 자유의 몸이 되어라!");
        Console.ReadKey(true);
    }

    public override void Input()
    {
        Util.PrintTriangle(0,4,"쉬움 난이도(빚 200만)","어려움 난이도(빚 1200만)","헬 난이도(빚 3000만)","묵시록 난이도(빚 9999만)");
    }

    public override void Result()
    {
        if(Console.GetCursorPosition() ==(0,4)) 
        {
            Console.Clear();
            GameManager.Instance.Dept = 2_000_000;
            Util.PrintWord("[쉬움 난이도]",ConsoleColor.Green);
            Console.WriteLine();
            Util.PrintWordLine("15만원부터 시작, 빚 200만으로 도전합니다.");
        }
        else if (Console.GetCursorPosition() == (0, 5))
        {
            Console.Clear();
            GameManager.Instance.Dept = 12_000_000;
            Util.PrintWord("[어려움 난이도]",ConsoleColor.DarkYellow);
            Console.WriteLine();
            Util.PrintWordLine("15만원부터 시작, 빚 1200만으로 도전합니다.");
        }
        else if (Console.GetCursorPosition() == (0, 6))
        {
            Console.Clear();
            GameManager.Instance.Dept = 30_000_000;
            Util.PrintWord("[헬 난이도]",ConsoleColor.DarkRed);
            Console.WriteLine();
            Util.PrintWordLine("15만원부터 시작, 빚 3000만으로 도전합니다.");
        }
        else 
        {
            Console.Clear();
            GameManager.Instance.Dept = 99_999_999;
            Util.PrintWord("[묵시록 난이도]",ConsoleColor.Red);
            Console.WriteLine();
            Util.PrintWordLine("15만원부터 시작, 빚 9999만으로 도전합니다.");            
        }
    }

    public override void Update()
    {
        Thread.Sleep(1000);
        Console.WriteLine();
        Util.PrintWord("도박 묵시록 ",ConsoleColor.White,200);
        Thread.Sleep(500);
        Util.PrintWord("경",ConsoleColor.Blue,600);
        Console.Write(" ");
        Util.PrintWord("이",ConsoleColor.Blue,600);
        Console.Write(" ");
        Util.PrintWord("리",ConsoleColor.Blue,600);
        Thread.Sleep(1600);
    }
}