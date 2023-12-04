using System.Collections;
using UnityEngine;

public class EnemyController : Unit
{
    private float _activeArea = 100;
    private Vector3 _targetPosition;
    private Node _targetNode;

    private IEnumerator RandomMove(float duration)
    {
        yield return new WaitForSeconds(3);
        Node current = MapManager.Instance.grid.GetNode(transform.position);
        _targetPosition = transform.position + new Vector3(Random.Range(-_activeArea, _activeArea), Random.Range(-_activeArea, _activeArea));
        Node random = MapManager.Instance.grid.GetNode(_targetPosition);
        if(random == null || !random.walkable)
        {
            StartCoroutine(RandomMove(0));
        }
        else
        {
            PathRequestManager.Instance.RequestPath(transform.position, random.center, OnPathFound);
        }
    }

    private void Start()
    {
        onCompleted = () => StartCoroutine(RandomMove(3));
        onTouch = () => { PathRequestManager.Instance.RequestPath(transform.position, _targetPosition, OnPathFound); };
        StartCoroutine(RandomMove(1));
    }
}
