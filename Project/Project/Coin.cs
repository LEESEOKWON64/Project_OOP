namespace Project;

public struct Coin
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int count { get; set; }

    private int _price;

    public int Price
    {
        get { return _price; }
    }
    public int SetPrice()
    {
        Random rnd = new Random();
        if (_price == null)
        {
            _price = rnd.Next(-50, 50);
        }
        int num = rnd.Next(0, 100);
        _price = (int)((1+num/100) * _price);
        return _price;
    }
}