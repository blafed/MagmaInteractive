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
    float _currentRatio = 1;

    public Prop() { }
    public Prop(float max, float ratio = 1)
    {
        this.max = max;
        this.ratio = ratio;
    }

    public float max
    {
        get => _max;
        set => _max = Mathf.Max(0, value);
    }

    public float ratio
    {
        get => _currentRatio;
        set => _currentRatio = Mathf.Clamp01(value);
    }
    public float current
    {
        get => _currentRatio * max;
        set => _currentRatio = Mathf.Clamp01(value / max);
    }

}