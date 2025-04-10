using System.Collections.Specialized;
using System.Threading.Channels;

namespace Project.Scenes;

public class TitleScene : Scene
{
    private DifficultyLevel[] levels;

    public TitleScene()
    {
        levels = new DifficultyLevel[4];
        levels[0] = new DifficultyLevel() { debt = 2_000_000, name = "쉬움", strDebt = "200만"};
        levels[1] = new DifficultyLevel() { debt = 12_000_000, name = "어려움", strDebt = "1200만"};
        levels[2] = new DifficultyLevel() { debt = 30_000_000, name = "헬", strDebt = "3000만"};
        levels[3] = new DifficultyLevel() { debt = 99_999_999, name = "묵시록", strDebt = "9999만"};
    }

    
    
    
    public override void Render()
    {
        Console.WriteLine("본 게임은 저장과 불러오기가 불가능한 \"게임\"입니다.");
        Util.PrintLine("부디 오락, 게임으로만 즐겨주세요.",0,ConsoleColor.Red);
        Thread.Sleep(3500);
        Console.Clear();
        Util.PrintWordLine("OOP 콘솔 프로젝트가 끝난 뒤 얼마지나지 않은 시점");
        Util.PrintWordLine("경이리는 KY마을에서 \"카지노\"를 발견하게 된다.");
        Util.PrintWordLine("훈련지원금을 받은 경이리는 유흥으로 도박을 하기 시작했고,");
        Util.PrintWord("전재산 ");
        Util.PrintWord("4천만돈",ConsoleColor.Red);
        Util.PrintWordLine("을 잃고");
        Util.PrintWord("거액",ConsoleColor.Red);
        Util.PrintWordLine("의 빚을 지게 되었다.");
        Util.PrintWaiting();
        Console.Clear();
        Util.PrintWordLine("그렇게 경이리 수중에 남은 돈, 15만 돈...");
        Util.PrintWordLine("이 돈으로 경이리는 기사회생에 나선다!");
        Util.PrintWordLine("도박으로 빚을 갚고 자유의 몸이 되어라!");
        Util.PrintWaiting();
    }

    public override void Input()
    {
        int decision = 0;
        Util.PrintTriangle(0,7,ref decision, out ConsoleKey newInput,"쉬움 난이도(빚 200만)","어려움 난이도(빚 1200만)","헬 난이도(빚 3000만)","묵시록 난이도(빚 9999만)");
    }

    public override void Result()
    {
        switch (Console.GetCursorPosition())
        {
            case (0,7): GameManager.Instance.Level = levels[0]; break;
            case (0,8): GameManager.Instance.Level = levels[1]; break;
            case (0,9): GameManager.Instance.Level = levels[2]; break;
            case (0,10): GameManager.Instance.Level = levels[3]; break;
        }
    }

    public override void Update()
    {
        Console.Clear();
        GameManager.Instance.Dept = GameManager.Instance.Level.debt;
        Util.PrintWord($"[{GameManager.Instance.Level.name} 난이도]",ConsoleColor.DarkYellow);
        Console.WriteLine();
        Util.PrintWordLine($"15만원부터 시작, 빚 {GameManager.Instance.Level.strDebt}으로 도전합니다.");
        
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