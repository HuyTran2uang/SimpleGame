using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : Controller
{
    public float speed;

    private void Awake()
    {
        GameManager.update += HandleUpdate;
    }

    private void Start()
    {
        PathfindSystem.Instance.Add(unique);
    }

    private void HandleUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Utilities.TimeRunFunc(FindAndMove);
        }
    }

    private void FindAndMove()
    {
        Node start = GridManager.Instance.GetNode(transform.position);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Node end = GridManager.Instance.GetNode(worldPos);
        List<Node> path = PathfindSystem.Instance.FindPath(start.center, end.center, unique);
        if (path != null)
        {
            StopAllCoroutines();
            StartCoroutine(FollowPath(path));
        }
    }

    private IEnumerator FollowPath(List<Node> path)
    {
        while (path.Count > 0)
        {
            yield return null;
            Vector3 target = path.First().center;
            if(transform.position == target)
                path.RemoveAt(0);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
}
