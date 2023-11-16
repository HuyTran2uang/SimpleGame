using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRequestManager : MonoBehaviourSingleton<PathRequestManager>, IInitor
{
    struct PathRequest
    {
        public Vector3 pathStart;
        public Vector3 pathTarget;
        public Action<Vector3[], bool> onMoveFollowPath;

        public PathRequest(Vector3 pathStart, Vector3 pathTarget, Action<Vector3[], bool> onMoveFollowPath)
        {
            this.pathStart = pathStart;
            this.pathTarget = pathTarget;
            this.onMoveFollowPath = onMoveFollowPath;
        }
    }

    Queue<PathRequest> pathRequests = new Queue<PathRequest>();
    PathRequest currentPathRequest;
    Pathfinding pathfinding;

    void IInitor.Init()
    {
        pathfinding = new Pathfinding();
    }

    public static void RequestPath(Vector3 startPos, Vector3 targetPos, Action<Vector3[], bool> onMoveFollowPath)
    {
        
    }
}
