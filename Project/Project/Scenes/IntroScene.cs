namespace Project.Scenes;

public struct Intro
{
    public void Print()
    {
        Util.PrintWordLine("난 경일 아카데미를 두 번이나 구한 용사 경이리야");
        Util.PrintWordLine("하지만 도박에 정신이 팔려 내 그래픽카드까지 팔아버렸지...");
        Util.PrintWordLine($"거기에 {GameManager.Instance.Level.strDebt}원의 빚까지 생겨버렸어");
        Util.PrintWordLine("...그러니까 도박으로 빚을 탕감해보자!!!");
        Util.PrintWaiting();
        Console.Clear();
        Util.PrintWordLine("뭐? 코딩을 해서 똑바로 돈을 벌라고?");
        Thread.Sleep(500);
        Util.PrintWordLine("못한다고... 그런거...");
        Thread.Sleep(1000);
        Util.PrintWordLine($"어쨋든 15만원을 {GameManager.Instance.Level.strDebt}원으로 불려야해!");
        Util.PrintWordLine("그럼 네 운을 믿을께!!");
        Util.PrintWaiting();
        Console.Clear();
        Util.PrintLine("[주의사항]",0,ConsoleColor.Red);
        Util.PrintLine("돈을 갚을 때는 지갑 혹은 저금통에");
        Util.PrintLine("1돈이라도 남겨놓으셔야합니다.");
        Util.PrintLine("그러지 않으면 게임 오버됩니다.");
        Util.PrintWaiting();
        Console.Clear();
        Util.PrintLine("[주의사항]",0,ConsoleColor.Red);
        Util.PrintLine("지갑은 999만 9999원까지만 비축이 가능하며");
        Util.PrintLine("저금통은 9999만 9999원까지만 비축이 가능합니다.");
        Util.PrintLine("그 점 유의해주시고 플레이해주시길 바랍니다.");
        Util.PrintLine("플레이하기 위해 아무 키나 누르세요.");
        Console.ReadKey(true);
    }
}