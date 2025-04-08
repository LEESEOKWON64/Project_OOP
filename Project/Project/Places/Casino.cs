namespace Project.Places;

public class Casino : Place
{
    public Casino()
    {
        this.Symbol = 'C';
        this.Color = ConsoleColor.DarkYellow;
        this.Map = new char[8, 8]
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
    }
    
    
    public override void Interact()
    {
        
    }
}