using Codice.Utils;
using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    Grounding grounding;
    public Duration interval = new Duration(0.1f);
    Rigidbody2D rb;

    public int maxJumps = 1;
    public float jumpForce = 10f;


    public bool isJumping => jumpsCounter > 0;

    float timeSinceJump;


    int jumpsCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        grounding = GetComponent<Grounding>();

        if (grounding)
        {
            grounding.onGrounded += ResetJumps;
        }
    }
    public bool CanJump()
    {
        if (grounding && !grounding.isGrounded && jumpsCounter == 0)
        {
            return false;
        }
        return jumpsCounter < maxJumps && interval.isDone;
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        interval.Start();
        jumpsCounter++;
        timeSinceJump = 0;
    }

    public void ResetJumps()
    {
        jumpsCounter = 0;
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            timeSinceJump += Time.fixedDeltaTime;
        }
        if (timeSinceJump >= JumpConfig.instance.flushInterval)
        {
            ResetJumps();
        }
    }


}