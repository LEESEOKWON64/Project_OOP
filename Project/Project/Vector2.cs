namespace Project;

public class Vector2
{
    private int x;
    private int y;

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public static bool operator == (Vector2 left, Vector2 right)
    {
        return left.x == right.x && left.y == right.y;
    }
    
    public static bool operator != (Vector2 left, Vector2 right)
    {
        return left.x != right.x || left.y != right.y;
    }
}