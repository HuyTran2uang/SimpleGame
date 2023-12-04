using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public void StartFinfPath(MonoBehaviour mono, Vector3 startPos, Vector3 targetPos, Grid grid, Action<Vector3[], bool> onFindFinished)
    {
        mono.StartCoroutine(FindPath(startPos, targetPos, grid, onFindFinished));
    }

    private IEnumerator FindPath(Vector3 startPos, Vector3 targetPos, Grid grid, Action<Vector3[], bool> onFindFinished)
    {
        Node start = grid.GetNode(startPos);
        Node target = grid.GetNode(targetPos);
        Heap<Node> open = new Heap<Node>(grid.Size);
        HashSet<Node> closed = new HashSet<Node>();
        bool isSuccess = false;
        Vector3[] waypoints = new Vector3[0];

        open.Add(start);

        while (open.Count > 0)
        {
            Node current = open.GetAndRemoveFirst();
            closed.Add(current);

            if (current == target)
            {
                isSuccess = true;
                break;
            }

            foreach (Node neighbour in grid.GetNeighbours(current))
            {
                if (!neighbour.walkable && neighbour != target || closed.Contains(neighbour))
                    continue;

                int new_gCost = current.gCost + GetDistance(current, neighbour);
                if (new_gCost < neighbour.gCost || !open.Contains(neighbour))
                {
                    neighbour.gCost = new_gCost;
                    neighbour.hCost = GetDistance(neighbour, target);
                    neighbour.parent = current;

                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                    else
                        open.UpdateItem(neighbour);
                }
            }
        }

        yield return null;
        if(isSuccess)
        {
            waypoints = RetracePath(start, target);
            isSuccess = waypoints.Length > 0;
        }
        onFindFinished.Invoke(waypoints, isSuccess);
    }
    
    private Vector3[] RetracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node current = end;

        while (current != start)
        {
            path.Add(current);
            current = current.parent;
        }

        Vector3[] waypoint = SimplifyPath(path);
        Array.Reverse(waypoint);
        return waypoint;
    }

    private Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 0; i < path.Count - 1; i++)
        {
            Vector2 directionNew = new Vector2(path[i].x - path[i + 1].x, path[i].y - path[i + 1].y);
            //if(directionNew != directionOld)
            //{
            //    waypoints.Add(path[i].center);
            //}
            //directionOld = directionNew;
            waypoints.Add(path[i].center);
        }

        return waypoints.ToArray();
    }

    private int GetDistance(Node nodeA, Node nodeB)
    {
        return Mathf.Abs(nodeA.x - nodeB.x) + Mathf.Abs(nodeA.y - nodeB.y);
    }
}
