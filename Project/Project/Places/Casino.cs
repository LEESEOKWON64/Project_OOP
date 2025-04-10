using Project.CasinoObjects;

namespace Project.Places;

public class Casino : Place
{
    public Casino()
    {
        _name = "casino";
        Map = new char[8, 18]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new BlackJackObject(new Vector2(17,2)));
        _objs.Add(new ATMObject(new Vector2(32,2)));
        _objs.Add(new SlotMachineObject(new Vector2(20,4)));
        _objs.Add(new SnifflingObject(new Vector2(17,7)));
        _objs.Add(new FieldObject(new Vector2(32,7)));
    }
}