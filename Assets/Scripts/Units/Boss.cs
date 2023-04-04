using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss current;

    public Health health { get; private set; }

    private void Awake()
    {
        if (!current)
            current = this;
        health = GetComponent<Health>();
    }
}