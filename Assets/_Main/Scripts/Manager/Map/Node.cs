using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector2 Coordinate { get; private set; }
    public bool IsWalkable { get; private set; }
    public Vector3 Center { get; private set; }
    public int GCost { get; set; }
    public int HCost { get; set; }
    public int FCost => GCost + HCost;

    public Node(Vector2 coordinate, bool isWalkable, Vector3 center)
    {
        Coordinate = coordinate;
        IsWalkable = isWalkable;
        Center = center;
    }
}
