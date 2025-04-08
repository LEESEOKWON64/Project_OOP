namespace Project.Places;

public class Field : Place
{
    public Field()
    {
        _name = "field";
        Map = new char[8, 13]
        {
            { ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new CasinoObject(new Vector2(4,0)));
        _objs.Add(new HomeObject(new Vector2(0,4)));
        _objs.Add(new LotteryObject(new Vector2(13,4)));
        _objs.Add(new SmithyObject(new Vector2(8,8)));
    }
    
}