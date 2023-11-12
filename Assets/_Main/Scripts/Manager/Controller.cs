using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public string unique;

    private void Reset()
    {
        unique = $"{GetInstanceID()}";
    }
}
