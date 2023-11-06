using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleGame
{
    public class Pathfinding
    {
        Grid _grid;

        public void FindPath(Node start, Node target)
        {
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();

            open.Add(start);

            while (open.Count > 0)
            {
                Node current = open[0];
                foreach (Node node in open)
                {
                    if(node.FCost < current.FCost)
                        current = node;
                }
                open.Remove(current);
                closed.Add(current);

                if(current == target)
                    return;

                foreach (Node neighbour in _grid.GetNeighbourNodes(current))
                {
                    
                }
            }
        }

        private int Distance(Node start, Node target)
        {
            int dx = Mathf.Abs(start.X - target.X);
            int dy = Mathf.Abs(start.Y - target.Y);
            return dx + dy;
        }
    }
}
