using UnityEngine;

public class DestroyOnKilled : MonoBehaviour
{
    public GameObject effectPrefab;
    public float delay = 0;


    private void Awake()
    {
        GetComponentInParent<Health>().onKilled += OnKilled;
    }

    private void OnKilled()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, delay);
    }
}