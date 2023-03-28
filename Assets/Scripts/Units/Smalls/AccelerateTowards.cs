using UnityEngine;

public class AccelerateTowards : MonoBehaviour
{
    public float speed = 1;
    public float damping = 1;
    public Transform target;
    public Vector2 offset;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {

        var targetPosition = (target ? target.position : Vector3.zero) + (Vector3)offset;
        var diff = targetPosition - transform.position;
        var dir = diff.normalized;
        var force = dir * speed * rb.mass;
        rb.AddForce(force, ForceMode2D.Force);
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
    }
}






