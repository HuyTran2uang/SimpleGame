using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviourSingleton<GridManager>
{
    public Tilemap map;
    public Node[,] grid;

    private void Awake()
    {
        CreateMap();
        GameManager.update += UpdateGrid;
        GameManager.gizmos += DrawGizmos;
    }

    private void CreateMap()
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

    private void UpdateGrid()
    {
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                Vector3 center = map.GetCellCenterWorld(map.cellBounds.min + new Vector3Int(x, y, 0));
                bool isWalkable = !Physics2D.OverlapCircle(center, .45f);
                grid[x, y].isWalkable = isWalkable;
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

    private void DrawGizmos()
    {
        for (int x = 0; x < map.size.x; x++)
        {
            for (int y = 0; y < map.size.y; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                Vector3 center = map.GetCellCenterWorld(map.cellBounds.min + (Vector3Int)coordinate);
                Gizmos.color = grid[x, y].isWalkable ? Color.green : Color.red;
                Gizmos.DrawCube(center, map.cellSize * .9f);
            }
        }

        Gizmos.color = Color.blue;
        Node mouseNode = GetNode(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 pos;
        Vector2 size = map.cellSize * .9f;
        if (mouseNode != null)
        {
            pos = mouseNode.center;
            Gizmos.DrawCube(pos, size);
        }

        //pos = PlayerController.Instance.transform.position;
        //Gizmos.color = Color.white;
        //Gizmos.DrawCube(pos, size);
    }
}
