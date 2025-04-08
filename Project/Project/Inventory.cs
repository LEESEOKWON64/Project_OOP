namespace Project;

public class Inventory<T>
{
    private List<T> inventory;
    
    public Inventory()
    {
        inventory = new List<T>();
    }
}