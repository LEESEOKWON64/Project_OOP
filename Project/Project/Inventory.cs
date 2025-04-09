using System.Threading.Channels;

namespace Project;

public class Inventory<T>
{
    private List<T> inven;

    public List<T> Inven
    {
        get { return inven; }
        set { inven = value; }
    }
    
    public Inventory()
    {
        inven = new List<T>();
    }


    public void Remove(T item)
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