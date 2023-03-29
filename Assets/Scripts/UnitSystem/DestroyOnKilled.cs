using UnityEngine;

public class DestroyOnKilled : MonoBehaviour
{
    public GameObject effectPrefab;


    private void Awake()
    {
        GetComponentInParent<Health>().onKilled += OnKilled;
    }

    private void OnKilled()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}