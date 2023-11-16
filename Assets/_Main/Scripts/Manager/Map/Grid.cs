using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Grid
{
    public Tilemap map;
    public Node[,] grid;

    public Grid(Tilemap map)
    {
        this.map = map;
        CreateMap();
    }

    public void CreateMap()
    {
        grid = new Node[map.size.x, map.size.y];
        //create grid
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                Vector3 center = map.GetCellCenterWorld(map.cellBounds.min + new Vector3Int(x, y, 0));
                bool isWalkable = !Physics2D.OverlapCircle(center, .45f);
                Node node = new Node(x, y, isWalkable, center);
                grid[x, y] = node;
            }
        }

        //set neighbours
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                if (x > 0) grid[x, y].neighbours.Add(grid[x - 1, y]);
                if (y > 0) grid[x, y].neighbours.Add(grid[x, y - 1]);
                if (x + 1 < map.size.x) grid[x, y].neighbours.Add(grid[x + 1, y]);
                if (y + 1 < map.size.y) grid[x, y].neighbours.Add(grid[x, y + 1]);
            }
        }
    }

    public void UpdateGrid()
    {
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                Vector3 center = map.GetCellCenterWorld(map.cellBounds.min + new Vector3Int(x, y, 0));
                bool isWalkable = !Physics2D.OverlapCircle(center, .45f);
                grid[x, y].walkable = isWalkable;
            }
        }
    }

    public Node GetNode(Vector3 pos)
    {
        Vector3Int cell = map.WorldToCell(pos);
        Vector3Int botLeft = map.cellBounds.min;
        int x = Mathf.RoundToInt((cell.x - botLeft.x) / map.cellSize.x);
        int y = Mathf.RoundToInt((cell.y - botLeft.y) / map.cellSize.y);
        if (x < 0 || y < 0 || x >= map.size.x || y >= map.size.y)
            return null;
        return grid[x, y];
    }

    public Node GetNode(int x, int y) => grid[x, y];

    public int Size => map.size.x * map.size.y;
    
    public List<Node> path;
}
