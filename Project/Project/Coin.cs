namespace Project;

public struct Coin
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _nickName;
    public string NickName
    {
        get { return _nickName; }
        set { _nickName = value; }
    }
    
    public int count { get; set; }

    private int _price;

    public int Price
    {
        get { return _price; }
    }

    public void SetPrice()
    {
        Random rnd = new Random();
        if (_price < 200)
        {
            _price = rnd.Next(500, 1000);
        }
    }
    public int SetPrice(out int change)
    {
        Random rnd = new Random();
        if (_price < 200)
        {
            _price = rnd.Next(500, 1000);
        }
        change = ChangePrice();
        int temp = _price;
        _price = (int)((1 + (float)change/100) * _price);
        change = _price - temp;
        return _price;
    }
    
    public int ChangePrice()
    {
        Random rnd = new Random();
        int num = rnd.Next(-33, 50);
        return num;
    }
}