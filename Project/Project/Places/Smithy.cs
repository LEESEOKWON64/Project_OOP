namespace Project.Places;

public class Smithy : Place
{
    public Smithy()
    {
        this.Symbol = 'S';
        this.Color = ConsoleColor.DarkBlue;
        this.Map = new char[8, 8]
        {
            { '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒' },
            { '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒' },
        };
    }
    
    public override void Interact()
    {
        
    }
}