using UnityEngine;

public class DestroyOnDie : MonoBehaviour
{
    public GameObject effectPrefab;
    Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.onDied += OnDie;
    }

    void OnDie()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}