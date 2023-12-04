using System;
using System.Collections.Generic;
using UnityEngine;

public class PathRequestManager : MonoBehaviourSingleton<PathRequestManager>, IInitable
{
    struct PathRequest
    {
        public Vector3 startPos;
        public Vector3 targetPos;
        public Action<Vector3[], bool> onMoveFollowPath;

        public PathRequest(Vector3 startPos, Vector3 targetPos, Action<Vector3[], bool> onMoveFollowPath)
        {
            this.startPos = startPos;
            this.targetPos = targetPos;
            this.onMoveFollowPath = onMoveFollowPath;
        }
    }

    Queue<PathRequest> pathRequests;
    PathRequest currentPathRequest;
    Pathfinding pathfinding;
    bool isProcessingPath;

    public void Init()
    {
        pathRequests = new Queue<PathRequest>();
        pathfinding = new Pathfinding();
    }

    public void RequestPath(Vector3 startPos, Vector3 targetPos, Action<Vector3[], bool> onMoveFollowPath)
    {
        var request = new PathRequest(startPos, targetPos, onMoveFollowPath);
        pathRequests.Enqueue(request);
        TryProcessNext();
    }

    private void TryProcessNext()
    {
        if(!isProcessingPath && pathRequests.Count > 0)
        {
            currentPathRequest = pathRequests.Dequeue();
            isProcessingPath = true;
            pathfinding.StartFinfPath(this, currentPathRequest.startPos, currentPathRequest.targetPos, MapManager.Instance.grid, FinishedProcessingPath);
        }
    }

    private void FinishedProcessingPath(Vector3[] path, bool success)
    {
        currentPathRequest.onMoveFollowPath(path, success);
        isProcessingPath = false;
        TryProcessNext();
    }
}
