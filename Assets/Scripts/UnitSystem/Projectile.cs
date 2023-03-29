using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public float damage = 20;
    public float range = 10;

    Vector2 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        startPosition = transform.position;
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        if (Vector2.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
}