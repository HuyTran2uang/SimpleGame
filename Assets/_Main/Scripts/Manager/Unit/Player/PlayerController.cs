using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : Unit
{
    private Vector3 _targetPosition;
    private void Start()
    {
        speed = 20;
        onTouch = () => { PathRequestManager.Instance.RequestPath(transform.position, _targetPosition, OnPathFound); };
        onCompleted = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PathRequestManager.Instance.RequestPath(transform.position, _targetPosition, OnPathFound);
        }
    }
}
