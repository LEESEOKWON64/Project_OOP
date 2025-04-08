namespace Project.Places;

public class Home : Place
{
    public Home()
    {
        this.Symbol = 'H';
        this.Color = ConsoleColor.Cyan;
        this.Map = new char[8, 8]
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
    }
    
    public override void Interact()
    {
        //Place.Enter();
    }
    
}