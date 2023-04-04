using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float speed = 10f;
    public Duration duration = new Duration(.7f);
    public Duration cooldown = new Duration(2);
    public Duration delay = new Duration(.3f);
    public float stopAfter = 1f;
    public int manaCost = 25;
    public bool flipCollider;
    public AudioSource audioSource;



    Movement movement;
    bool didDash = false;


    Rigidbody2D rb;
    Mana mana;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
        mana = GetComponent<Mana>();
    }

    public bool isDashing => !duration.isDone;

    public bool CanDash()
    {
        return duration.isDone && cooldown.isDone && (!mana || mana.HasAmount(manaCost));
    }
    public void Dash()
    {
        delay.Start();
        duration.Start();
        didDash = false;
        if (mana)
            mana.UseMana(manaCost);
        if (audioSource)
            audioSource.Play();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            if (delay.isDone && duration.elabsed < stopAfter)
            {
                if (!didDash)
                {
                    didDash = true;
                    rb.gravityScale = 0;
                    if (rb.velocity.y < 0)
                        rb.velocity = new Vector2(rb.velocity.x, 0);
                    if (flipCollider)
                    {
                        var capsule = GetComponent<CapsuleCollider2D>();
                        if (capsule)
                        {
                            capsule.direction = CapsuleDirection2D.Horizontal;
                            capsule.size = new Vector2(capsule.size.y, capsule.size.x);
                        }
                    }
                }
                transform.position += transform.right * transform.localScale.x * speed * Time.fixedDeltaTime;
                if (movement)
                    movement.inputMovement = Vector2.zero;
            }
        }

        if (duration.isDoneTrigger)
        {
            rb.gravityScale = 1;
            if (flipCollider)
            {
                var capsule = GetComponent<CapsuleCollider2D>();
                if (capsule)
                {
                    capsule.direction = CapsuleDirection2D.Vertical;
                    capsule.size = new Vector2(capsule.size.y, capsule.size.x);
                }
            }
            cooldown.Start();
        }

    }
}