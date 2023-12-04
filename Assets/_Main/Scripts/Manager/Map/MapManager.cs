using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviourSingleton<MapManager>, IReadData, IInitable
{
    public Tilemap[] maps;
    public int mapId; //index
    public Grid grid;

    public Tilemap GetCurrentMap => maps[mapId];

    public void Read()
    {
        mapId = 0;
    }

    public void Init()
    {
        grid = new Grid(GetCurrentMap);
    }

    private void Update()
    {
        grid.UpdateGrid();
    }

    public void ChangeMap(int id)
    {
        mapId = id;
    }
}
