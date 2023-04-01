using UnityEngine;

[System.Obsolete("Use DestroyOnKilled instead")]
public class DestroyOnDie : MonoBehaviour
{
    public GameObject effectPrefab;
    Health health;
    private void Awake()
    {
        health = GetComponent<Health>();
        health.onKilled += OnDie;
    }

    void OnDie()
    {
        if (effectPrefab != null)
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}