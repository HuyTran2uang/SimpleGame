using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x, y;
    public bool isWalkable;
    public Vector3 center;
    public Node parent;
    public List<Node> neighbours;
    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;

    public Node(int x, int y, bool isWalkable, Vector3 center)
    {
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
        this.center = center;
        neighbours = new List<Node>();
    }
}
