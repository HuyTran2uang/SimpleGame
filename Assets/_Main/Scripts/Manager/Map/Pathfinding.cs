using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform seeker, target;
    public Grid grid;

    private void Update()
    {
        FindPath(seeker.position, target.position);
    }

    public void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node start = grid.GetNode(startPos);
        Node target = grid.GetNode(targetPos);
        FindPath(start, target);
    }

    public void FindPath(Node start, Node target)
    {
        List<Node> open = new List<Node>();
        HashSet<Node> closed = new HashSet<Node>();

        open.Add(start);

        while (open.Count > 0)
        {
            Node current = open[0];
            foreach (Node node in open)
                if(node.fCost < current.fCost || node.fCost == current.fCost && node.hCost < current.hCost)
                    current = node;

            open.Remove(current);
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
        grid.path = path;
    }

    private int GetDistance(Node nodeA, Node nodeB)
    {
        return Mathf.Abs(nodeA.x - nodeB.x) + Mathf.Abs(nodeA.y - nodeB.y);
    }
}
