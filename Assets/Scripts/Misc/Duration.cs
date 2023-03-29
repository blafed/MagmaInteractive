using System;
using UnityEngine;
[Serializable]
public class Duration
{
    public float duration = 1;


    float time = float.MinValue;

    public Duration(float duration)
    {
        this.duration = duration;
    }
    public Duration() { }

    public float elabsed => Time.time - time;
    public float remaining => duration - elabsed;
    public bool isDone => remaining <= 0;
    public float progress => Mathf.Clamp01(elabsed / duration);

    bool wasDone;
    public bool isDoneTrigger
    {
        get
        {
            bool result = isDone && !wasDone;
            wasDone = isDone;
            return result;
        }
    }


    public void Start()
    {
        time = Time.time;
    }
}