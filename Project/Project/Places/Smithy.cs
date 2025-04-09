﻿using Project.SmithyObjects;

namespace Project.Places;

public class Smithy : Place
{
    private GameObject _obj;
    public Smithy()
    {
        _name = "smithy";
        Map = new char[8, 8]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', '▒', ' ', ' ', '▒' },
            { '▒', ' ', '▒', ' ', ' ', ' ', ' ', '▒' },
            { '▒', ' ', '▒', '▒', '▒', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒' },
        };
        _objs = new List<GameObject>();
        _objs.Add(new FieldObject(new Vector2(6,7)));
        _objs.Add(new BlackSmithObject(new Vector2(3,1)));
        _objs.Add(new MerchantObject(new Vector2(3,5)));
        
    }
}