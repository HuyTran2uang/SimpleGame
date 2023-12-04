using UnityEngine;

public class Node : IHeapItem<Node>
{
    public int x, y;
    public bool walkable;
    public Vector3 center;
    public Node parent;
    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;


    public Node(int x, int y, bool isWalkable, Vector3 center)
    {
        this.x = x;
        this.y = y;
        this.walkable = isWalkable;
        this.center = center;
    }

    public int Index { get; set; }

    public int CompareTo(Node node)
    {
        int compare = fCost.CompareTo(node.fCost);

        if (compare == 0)
        {
            compare = hCost.CompareTo(node.hCost);
        }

        return -compare;
    }
}
