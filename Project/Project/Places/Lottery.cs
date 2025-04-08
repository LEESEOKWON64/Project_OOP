using Project.CasinoObjects;
using Project.HomeObjects;
using Project.LotteryObjects;

namespace Project.Places;

public class Lottery : Place
{
    private GameObject _obj;
    public Lottery()
    {
        _name = "lottery";
        Map = new char[8, 8]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new FieldObject(new Vector2(6,7)));
        _objs.Add(new CreditorObject(new Vector2(4,2)));
    }
}