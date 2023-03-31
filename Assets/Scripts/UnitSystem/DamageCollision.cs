using UnityEngine;

public class DamageCollision : DamageBase
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollider(other.collider);
    }
}