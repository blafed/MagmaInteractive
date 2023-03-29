using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 1f;

    private void Start()
    {
        Destroy(gameObject, time);
    }
}