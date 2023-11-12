using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : Controller
{
    public bool canScan;
    public float speed;
    public int scope;
    public Vector3 defPoint;

    private void Awake()
    {
        defPoint = transform.position;
        GameManager.update += HandleUpdate;
    }

    private void Start()
    {
        PathfindSystem.Instance.Add(unique);
        StartCoroutine(Rest(2));
    }

    private void HandleUpdate()
    {
        if(canScan)
        {
            canScan = false;
            RanomPosAndMove();
        }
    }

    private Node GetRandomNode()
    {
        System.Random rnd = new System.Random();
        Node defNode = GridManager.Instance.GetNode(defPoint);
        Node end = GridManager.Instance.GetNode(rnd.Next(scope) + defNode.x, rnd.Next(scope) + defNode.y);
        if (end == null || !end.isWalkable) return GetRandomNode();
        return end;
    }

    private void RanomPosAndMove()
    {
        Node end = GetRandomNode();
        List<Node> path = PathfindSystem.Instance.FindPath(transform.position, end.center, unique);
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
            if (transform.position == target)
                path.RemoveAt(0);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        StartCoroutine(Rest(2));
    }

    private IEnumerator Rest(float duration)
    {
        yield return new WaitForSeconds(duration);
        canScan = true;
    }
}
