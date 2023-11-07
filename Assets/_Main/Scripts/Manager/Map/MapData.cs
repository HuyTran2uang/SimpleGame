using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public Vector2Int Size
    {
        get { return new Vector2Int(10, 10); }
    }

    private int[,] _mapData = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1},
        {1,0,0,1,0,0,0,0,0,1},
        {1,0,0,1,0,0,0,0,0,1},
        {1,0,0,1,0,1,1,1,1,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,1,1,1,1,0,0,0,1},
        {1,0,1,0,0,0,0,0,0,1},
        {1,0,1,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1},
    };
}
