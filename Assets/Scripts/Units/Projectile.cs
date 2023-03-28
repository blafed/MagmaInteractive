using System.Collections.Generic;
using UnityEngine;

public class Projectile : Unit
{
    public Unit owner { get; set; }
    public Weapon weapon { get; set; }

    public float damage = 10;
    public int maxHits = 0;

    HashSet<Health> hitTargets = new HashSet<Health>();

    public virtual void ApplyDamage(Health health)
    {

    }



    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        if (health != null && health.unit != owner)
        {
            ApplyDamage(health);
        }
    }
}