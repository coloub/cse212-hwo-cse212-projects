public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert Unique Values Only - no duplicates allowed
        if (value == Data)
        {
            // Value already exists, do not insert duplicate
            return;
        }
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Contains - recursive search
        if (value == Data)
        {
            return true;
        }
        else if (value < Data && Left is not null)
        {
            return Left.Contains(value);
        }
        else if (value > Data && Right is not null)
        {
            return Right.Contains(value);
        }
        
        return false;
    }

    public int GetHeight()
    {
        // Problem 4: Tree Height - recursively return height
        int leftHeight = 0;
        int rightHeight = 0;
        
        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }
        
        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }
        
        // Height is 1 + max height of subtrees
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}