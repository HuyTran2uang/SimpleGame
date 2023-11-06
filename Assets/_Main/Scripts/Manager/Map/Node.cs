using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class Node
    {
        public Node(int x, int y, Vector3 centerPos, bool walkable)
        {
            X = x;
            Y = y;
            CenterPos = centerPos;
            Walkable = walkable;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Vector3 CenterPos {get; private set; }
        public bool Walkable {get; set;}
        public int GCost {get; set;}
        public int HCost { get; set;}
        public int FCost => GCost + HCost;
    }
}
