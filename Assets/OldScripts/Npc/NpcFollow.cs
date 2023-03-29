using UnityEngine;

using UnityEngine;

public class NpcFollow : MonoBehaviour
{
    public bool allowVerticalMovement;
    public float speed = 1;
    public Transform target;


    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }
        var diff = target.position - transform.position;
        var dir = diff.normalized;
        var velocity = dir * speed;
        if (!allowVerticalMovement)
        {
            velocity.y = 0;
        }
        ApplyVelocity(velocity);
    }


    public virtual void ApplyVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}