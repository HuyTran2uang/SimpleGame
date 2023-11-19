using System.Linq;
using UnityEngine;

public class Root : MonoBehaviourSingleton<Root>
{
    private void Awake()
    {
        LoadData();
        Init();
    }

    private void Start()
    {

    }

    private void LoadData()
    {
        var readers = FindObjectsOfType<MonoBehaviour>().OfType<IReadData>();
        foreach (var reader in readers)
            reader.Read();
    }

    private void Init()
    {
        var initors = FindObjectsOfType<MonoBehaviour>().OfType<IInitable>();
        foreach (var initor in initors)
            initor.Init();
    }
}
