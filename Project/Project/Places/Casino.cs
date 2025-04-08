using Project.CasinoObjects;

namespace Project.Places;

public class Casino : Place
{
    public Casino()
    {
        _name = "casino";
        Map = new char[8, 8]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new BlackJackObject(new Vector2(1,1)));
        _objs.Add(new CasherObject(new Vector2(6,1)));
        _objs.Add(new SlotMachineObject(new Vector2(4,3)));
        _objs.Add(new SnifflingObject(new Vector2(1,6)));
        _objs.Add(new FieldObject(new Vector2(6,7)));
    }
}