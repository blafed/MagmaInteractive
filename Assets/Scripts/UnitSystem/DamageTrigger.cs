using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    public float damage = 10;
    public float selfDamage;
    public bool selfKill;
    Health health;

    private void Awake()
    {
        health = GetComponentInParent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponentInParent<Health>();
        if (otherHealth)
        {
            otherHealth.TakeDamage(damage);
            if (selfKill)
                health.Kill();
            else
            if (selfDamage != 0)
                health.TakeDamage(selfDamage);
        }
    }
}