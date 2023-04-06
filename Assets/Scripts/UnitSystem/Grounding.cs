using UnityEngine;

public class Grounding : MonoBehaviour
{
    public Rigidbody2D rb
    {
        get; private
    set;
    }
    new Collider2D collider;

    public bool isGrounded { get; private set; }
    public float groundTime { get; private set; }
    public float airTime { get; private set; }
    public bool isFalling => !isGrounded && rb.velocity.y < 0.5f;

    public event System.Action onGrounded;


    public bool useCustomGroundLayer = false;
    public LayerMask customGroundLayer;


    bool wasGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    private void FixedUpdate()
    {
        wasGrounded = isGrounded;

        Vector2 position = transform.position;
        var groundCheckDistance = GroundingConfig.instance.groundCheckDistance;
        var groundLayer = useCustomGroundLayer ? customGroundLayer : GroundingConfig.instance.groundLayer;

        Physics2D.queriesHitTriggers = false;
        isGrounded = Physics2D.Raycast(position, Vector2.down, groundCheckDistance, groundLayer)
        || collider && (
        Physics2D.Raycast(position + Vector2.right * collider.bounds.size.x * .5f, Vector2.down, groundCheckDistance, groundLayer)
        | Physics2D.Raycast(position - Vector2.right * collider.bounds.size.x * .5f, Vector2.down, groundCheckDistance, groundLayer));
        Physics2D.queriesHitTriggers = true;


        if (isGrounded)
        {
            groundTime += Time.fixedDeltaTime;
        }
        else
        {
            airTime += Time.fixedDeltaTime;
        }


        if (isGrounded && !wasGrounded)
        {
            onGrounded?.Invoke();
        }
    }



}