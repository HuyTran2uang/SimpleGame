using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public Pathfinding() { }

    public void FindPath(Vector3 startPos, Vector3 targetPos, Grid grid)
    {
        Node start = grid.GetNode(startPos);
        Node target = grid.GetNode(targetPos);
        FindPath(start, target, grid);
    }

    private void FindPath(Node start, Node target, Grid grid)
    {
        Heap<Node> open = new Heap<Node>(grid.Size);
        HashSet<Node> closed = new HashSet<Node>();

        open.Add(start);

        while (open.Count > 0)
        {
            Node current = open.GetAndRemoveFirst();
            closed.Add(current);

            if (current == target)
            {
                RetracePath(start, target);
                return;
            }

            foreach (Node neighbour in current.neighbours)
            {
                if(!neighbour.walkable || closed.Contains(neighbour))
                    continue;

                int new_gCost = current.gCost + GetDistance(current, neighbour);
                if(new_gCost < neighbour.gCost || !open.Contains(neighbour))
                {
                    neighbour.gCost = new_gCost;
                    neighbour.hCost = GetDistance(neighbour, target);
                    neighbour.parent = current;

                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                }
            }
        }

        grid.path = null;
        return;
    }
    
    private void RetracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node current = end;

        while (current != start)
        {
            path.Add(current);
            current = current.parent;
        }
        path.Reverse();
    }

    private int GetDistance(Node nodeA, Node nodeB)
    {
        return Mathf.Abs(nodeA.x - nodeB.x) + Mathf.Abs(nodeA.y - nodeB.y);
    }
}
