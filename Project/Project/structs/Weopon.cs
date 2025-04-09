namespace Project;

public struct Weopon
{
    private string _name;
    public string Name{ get => _name; set => _name = value; }
    
    private int _enforce;
    public int Enforce{ get => _enforce; set => _enforce = value; }
    
    private int _price;
    public int Price{ get => _price; set => _price = value; } 
    
    private float _successProb;
    public float SuccessProb{ get => _successProb; set => _successProb = value; } 
    
    private float _failProb;
    public float FailProb{ get => _failProb; set => _failProb = value; } 
    
    private float _destructProb;
    public float DestructProb{ get => _destructProb; set => _destructProb = value; } 
}