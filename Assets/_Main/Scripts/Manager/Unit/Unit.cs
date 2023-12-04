using UnityEngine;
using System.Collections;
using System;

public class Unit : MonoBehaviour
{
    protected float speed = 2;
    Vector3[] path;
    int targetIndex;

    public void OnPathFound(Vector3[] newPath, bool isSuccessed)
    {
        if (isSuccessed)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    protected Action onCompleted, onTouch;
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    break;
                }
                currentWaypoint = path[targetIndex];
                var colliders = Physics2D.OverlapCircleAll(currentWaypoint, .45f);
                bool isTouch = false;
                foreach (var i in colliders)
                {
                    if (i.gameObject != this.gameObject)
                    {
                        isTouch = true;
                        break;
                    }
                }
                if (isTouch)
                {
                    onTouch?.Invoke();
                    break;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            
            yield return null;
        }
        onCompleted?.Invoke();
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                //Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}