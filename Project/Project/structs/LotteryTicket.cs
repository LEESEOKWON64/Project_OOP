namespace Project;

public struct LotteryTicket
{
    private int[] _numbers;

    public int[] Numbers
    {
        get { return _numbers; }
    }

    public LotteryTicket()
    {
        _numbers = new int[6];
    }

    public int[] SetAutoNumbers()
    {
        Random rnd = new Random();
        int num;
        for (int i = 0; i < _numbers.Length; i++)
        {
            while (_numbers[i] == 0)
            {
                num = rnd.Next(1, 10);
                if (!_numbers.Contains(num))
                {
                    _numbers[i] = num;
                }
            }
        }
        return _numbers;
    }
}