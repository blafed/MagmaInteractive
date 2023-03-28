using UnityEngine;

[System.Serializable]
public class TimerProp
{
    public float value = 1;


    public float elabsed => Time.time - time;
    public float remaining => value - elabsed;
    public bool isDone => remaining <= 0;
    public float progress => Mathf.Clamp01(elabsed / value);

    float time;

    public TimerProp() { }

    public TimerProp(float value)
    {
        this.value = value;
    }

    public void Start()
    {
        time = Time.time;
    }
}