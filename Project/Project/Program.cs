namespace Project;

class Program
{
    static void Main(string[] args)
    {
        GameManager.GetInstance();
        GameManager.Instance.Start();
        GameManager.Instance.Run();
        GameManager.Instance.End();
    }
}