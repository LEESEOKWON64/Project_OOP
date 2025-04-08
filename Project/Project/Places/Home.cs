using Project.HomeObjects;

namespace Project.Places;

public class Home : Place
{
    private GameObject _obj;
    public Home()
    {
        _name = "home";
        Map = new char[8, 8]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new ComputerObject(new Vector2(6,1)));
        _objs.Add(new LoverObject(new Vector2(1,1)));
        _objs.Add(new FieldObject(new Vector2(6,7)));
    }
}
