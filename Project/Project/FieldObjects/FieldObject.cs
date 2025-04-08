﻿namespace Project;

public class FieldObject : GameObject
{
    public FieldObject(Vector2 position)
    {
        _symbol = 'F';
        _color = ConsoleColor.DarkGreen;
        _position = position;
    }
    
    public override void Interact()
    {
        Util.FieldTriangle("밖","field");
        if (Player.Instance.NextPlace != Player.Instance.CurrentPlace)
        {
            Player.Instance.SetPosition(new Vector2(5,3));
        }
        Player.Instance.CurrentPlace = Player.Instance.NextPlace;
    }
}