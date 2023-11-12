using System;
using System.Diagnostics;
using UnityEngine;

public static class Utilities
{
    public static void TimeRunFunc(Action callback)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        callback.Invoke();
        stopwatch.Stop();
        UnityEngine.Debug.Log($"ms: {stopwatch.ElapsedMilliseconds}");
    }
}
