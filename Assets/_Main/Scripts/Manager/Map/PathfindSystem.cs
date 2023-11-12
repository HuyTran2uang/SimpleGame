using System.Collections.Generic;
using UnityEngine;

public class PathfindSystem : MonoBehaviourSingleton<PathfindSystem>
{
    Dictionary<string, Pathfinding> pathFindDic = new Dictionary<string, Pathfinding>();

    public void Add(string unique)
    {
        pathFindDic.Add(unique, new Pathfinding(
            GridManager.Instance.map.size.x, 
            GridManager.Instance.map.size.y, 
            GridManager.Instance.grid)
        );
    }

    public void Remove(string unique)
    {
        pathFindDic.Remove(unique);
    }

    public List<Node> FindPath(Vector3 startPos, Vector3 endPos, string unique)
    {
        return pathFindDic[unique].FindPath(startPos, endPos);
    }
}
