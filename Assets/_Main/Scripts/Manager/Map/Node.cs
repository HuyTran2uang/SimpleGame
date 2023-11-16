using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public int x, y;
    public bool walkable;
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
        this.walkable = isWalkable;
        this.center = center;
        neighbours = new List<Node>();
    }

    int IHeapItem<Node>.Index { get; set; }

    int IComparable<Node>.CompareTo(Node node)
    {
        int compare = fCost.CompareTo(node.fCost);

        if (compare == 0)
        {
            compare = hCost.CompareTo(node.hCost);
        }

        return -compare;
    }
}
