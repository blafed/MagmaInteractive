using UnityEngine;
using System;

[Serializable]
public class Prop
{
    [SerializeField]
    [Min(0)]
    float _max = 100;
    [SerializeField]
    [Range(0, 1)]
    float _current = 1;

    public Prop() { }
    public Prop(float max, float current = 1)
    {
        this.max = max;
        this.current = current;
    }

    public float max
    {
        get => _max;
        set => _max = Mathf.Max(0, value);
    }

    public float ratio
    {
        get => _current;
        set => _current = Mathf.Clamp01(value);
    }
    public float current
    {
        get => _current * max;
        set => _current = Mathf.Clamp01(value / max);
    }

}