using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Duration
{
    [FormerlySerializedAs("duration")]
    public float value = 1;


    float time = float.MinValue;

    public Duration(float duration)
    {
        this.value = duration;
    }
    public Duration() { }

    public float elabsed => Time.time - time;
    public float remaining => value - elabsed;
    public bool isDone => remaining <= 0;
    public float progress => Mathf.Clamp01(elabsed / value);
    public float postElabsed => Mathf.Max(elabsed - value, 0);

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
    public void StartWithDuration(float dur)
    {
        value = dur;
        Start();
    }
    public void Stop()
    {
        time = float.MinValue;
    }
}