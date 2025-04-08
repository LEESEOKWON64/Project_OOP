namespace Project.Places;

public class Field : Place
{
    public Field()
    {
        _name = "field";
        Map = new char[8, 13]
        {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ' },
            { ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ' },
            { ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new CasinoObject(new Vector2(3,1)));
        _objs.Add(new HomeObject(new Vector2(1,3)));
        _objs.Add(new LotteryObject(new Vector2(11,1)));
        _objs.Add(new SmithyObject(new Vector2(7,6)));
    }
}