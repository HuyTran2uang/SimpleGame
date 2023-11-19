using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviourSingleton<MapManager>, IReadData, IInitable
{
    public Tilemap[] maps;
    public int mapId; //index
    [HideInInspector] public Grid grid;

    public Tilemap GetCurrentMap => maps[mapId];

    void IReadData.Read()
    {
        mapId = 0;
    }

    void IInitable.Init()
    {
        grid = new Grid(GetCurrentMap);
    }

    public void ChangeMap(int id)
    {
        mapId = id;
    }
}
