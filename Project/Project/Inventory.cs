using System.Threading.Channels;

namespace Project;

public class Inventory<Coin>
{
    private List<Coin> inven;

    public List<Coin> Inven
    {
        get { return inven; }
        set { inven = value; }
    }
    
    public Inventory()
    {
        inven = new List<Coin>();
    }


    public void Remove(Coin item)
    {
        inven.Remove(item);
    }

    public void PrintAll()
    {
        if(inven.Count == 0) Console.WriteLine("");
        
        for (int i = 0; i < inven.Count; i++)
        {
            Console.WriteLine($"{i+1}. {inven[i]}");
        }
    }
}