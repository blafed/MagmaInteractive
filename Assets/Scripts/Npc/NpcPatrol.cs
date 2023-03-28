using UnityEngine;

public class NpcPatrol : MonoBehaviour
{
    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }
    public bool allowVerticalMovement;
    public float speed = 1f;
    public float patrolDistance = 2;

    float movementDir = 1;

    Vector2 patrolPosition;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        patrolPosition = transform.position;
    }



    private void FixedUpdate()
    {
        var velocity = Vector2.right * speed * movementDir;
        if (!allowVerticalMovement)
        {
            velocity.y = 0;
        }
        ApplyVelocity(velocity);

        if (Vector2.Distance(position, patrolPosition) > patrolDistance)
        {
            ReverseDir();
        }
    }



    public void ReverseDir()
    {
        patrolPosition = transform.position;
        movementDir *= -1;
    }


    public virtual void ApplyVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(position, position + Vector2.right * patrolDistance);
    }

}