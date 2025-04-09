namespace Project;

public struct LotteryTicket
{
    private int[] _numbers;

    public int[] Numbers
    {
        get { return _numbers; }
        set { _numbers = value; }
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
            while (_numbers.Length == i)
            {
                num = rnd.Next(0, 10);
                if (!_numbers.Contains(num))
                {
                    _numbers[i] = num;
                }
            }
        }
        return _numbers;
    }

    private int[] SetManualTicket(params int[] input)
    {
        _numbers = input;
        return _numbers;
    }
}