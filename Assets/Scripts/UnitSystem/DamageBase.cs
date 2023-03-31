using System.Collections.Generic;
using UnityEngine;

public class DamageBase : MonoBehaviour
{
    public float damage = 10;
    public float selfDamage;
    public bool selfKill;
    public Duration delay = new Duration(0);
    public bool multipleDamage = false;

    Health health;


    List<Health> damaged = new List<Health>();


    List<Health> toDamage = new List<Health>();
    private void Awake()
    {
        health = GetComponentInParent<Health>();
        delay.Start();
    }

    void ApplyDamage(Health otherHealth)
    {
        otherHealth.TakeDamage(damage);
        if (selfKill)
            health.Kill();
        else
        if (selfDamage != 0)
            health.TakeDamage(selfDamage);
    }


    private void FixedUpdate()
    {
        if (delay.isDoneTrigger)
        {
            foreach (var h in toDamage)
            {
                ApplyDamage(h);
            }
            toDamage.Clear();
        }
    }

    public void HandleCollider(Collider2D other)
    {
        Health otherHealth = other.GetComponentInParent<Health>();
        if (otherHealth)
        {

            if (!multipleDamage && damaged.Contains(otherHealth))
                return;
            if (!multipleDamage)
                damaged.Add(otherHealth);
            if (!delay.isDone)
            {
                toDamage.Add(otherHealth);
                return;
            }

            ApplyDamage(otherHealth);

        }
    }
}