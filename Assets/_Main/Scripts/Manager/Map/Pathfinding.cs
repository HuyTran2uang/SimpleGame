using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathNode
{
    public int x, y, gCost, hCost;
    public PathNode parent;
    public List<PathNode> neighbours;
    public int fCost => gCost + hCost;

    public PathNode(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Pathfinding
{
    PathNode[,] grid;

    public Pathfinding(int width, int height, Node[,] grid)
    {
        this.grid = new PathNode[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                
                this.grid[x, y] = new PathNode(x, y);
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var neightbours = grid[x, y].neighbours.Select(i => this.grid[i.x, i.y]).ToList();
                this.grid[x, y].neighbours = neightbours;
            }
        }
    }

    public List<Node> FindPath(Vector3 startPos, Vector3 endPos)
    {
        Node startNode = GridManager.Instance.GetNode(startPos);
        PathNode start = grid[startNode.x, startNode.y];
        Node endNode = GridManager.Instance.GetNode(endPos);
        PathNode end = grid[endNode.x, endNode.y];
        return FindPath(start, end);
    }

    public List<Node> FindPath(PathNode start, PathNode end)
    {
        List<PathNode> open = new List<PathNode>();
        HashSet<PathNode> closed = new HashSet<PathNode>();

        open.Add(start);

        while (open.Count > 0)
        {
            PathNode current = open[0];
            foreach (var node in open)
                if(node.fCost < current.fCost || node.fCost == current.fCost && node.hCost < current.hCost)
                    current = node;

            open.Remove(current);
            closed.Add(current);

            if (current == end) return RetracePath(start, end);

            foreach (var neighbour in current.neighbours)
            {
                if(!GridManager.Instance.GetNode(neighbour.x, neighbour.y).isWalkable || closed.Contains(neighbour))
                    continue;

                int new_gCost = current.gCost + Distance(current, neighbour);
                if(new_gCost < neighbour.gCost || !open.Contains(neighbour))
                {
                    neighbour.gCost = new_gCost;
                    neighbour.hCost = Distance(neighbour, end);
                    neighbour.parent = current;

                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                }
            }
        }

        return null;
    }

    private List<Node> RetracePath(PathNode start, PathNode end)
    {
        List<Node> path = new List<Node>();
        PathNode current = end;
        path.Add(GridManager.Instance.GetNode(current.x, current.y));
        while (current.parent != start)
        {
            current = current.parent;
            path.Add(GridManager.Instance.GetNode(current.x, current.y));
        }
        path.Reverse();
        return path;
    }

    private int Distance(PathNode nodeA, PathNode nodeB)
    {
        return Mathf.Abs(nodeA.x - nodeB.x) + Mathf.Abs(nodeA.y - nodeB.y);
    }
}
