using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [field: SerializeField] public Tilemap Map { get; private set; }
    public Node[,] Grid { get; private set; }
    public Vector2Int MapSize { get; private set; }
    public Vector2Int CellSize { get; private set; }
    public Vector3 BotLeftPos { get; private set; }

    public void Create()
    {
        BotLeftPos = Map.cellBounds.min;
    }
}
