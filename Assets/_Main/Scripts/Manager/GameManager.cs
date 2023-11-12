using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public delegate void Process();
public class GameManager : MonoBehaviour
{
    public static Process load;
    public static Process update;
    public static Process gizmos;

    private void Start()
    {
        load?.Invoke();
        StartCoroutine(HandleUpdate());
    }

    private IEnumerator HandleUpdate()
    {
        while (true)
        {
            yield return null;
            update?.Invoke();
        }
    }

    public bool isShowGizmos;
    private void OnDrawGizmos()
    {
        if (!isShowGizmos) return;
        gizmos?.Invoke();
    }
}
