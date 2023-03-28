using System;
using UnityEngine;
using System.Collections.Generic;
public static class Extensions
{
    public static float Squared(this float f) => f * f;
    public static float Abs(this float f) => Mathf.Abs(f);
    public static Vector3 ToVector3(this Vector2 v, float z = 0) => new Vector3(v.x, v.y, z);
    public static void ForEach<T>(this T[] list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }
    public static void ReActivate(this GameObject go)
    {
        go.SetActive(false);
        go.SetActive(true);
    }
}