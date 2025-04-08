namespace Project.CasinoObjects;

public class BlackJackObject : GameObject
{
        public BlackJackObject(Vector2 position)
        {
            _symbol = 'B';
            _color = ConsoleColor.Gray;
            _position = position;
        }
    
    public override void Interact()
    {
        
    }
}