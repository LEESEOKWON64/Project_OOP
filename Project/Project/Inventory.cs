using System.Threading.Channels;

namespace Project;

public class Inventory<T>
{
    private List<T> inventory;
    
    public Inventory()
    {
        inventory = new List<T>();
    }

    public void Add(T item)
    {
        inventory.Add(item);
    }

    public void Remove(T item)
    {
        inventory.Remove(item);
    }

    public void PrintAll()
    {
        if(inventory.Count == 0) Console.WriteLine("");
        
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i+1}. {inventory[i]}");
        }
    }
}