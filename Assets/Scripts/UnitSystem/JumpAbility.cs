using UnityEngine;

public class JumpAbility : MonoBehaviour
{
    public int secondJumpManaCost = 10;
    Grounding grounding;
    public Duration interval = new Duration(0.1f);
    Rigidbody2D rb;

    public int maxJumps = 1;
    public float jumpForce = 10f;
    public float secondJumpMultiplier = 1.2f;
    public Duration secondJumpDelay = new Duration(0.3f);
    public GameObject[] jumpEffects;
    public float jumpEffectDelay = 0.2f;



    public bool isJumping => jumpsCounter > 0;

    float timeSinceJump;
    bool didAddForce;
    Mana mana;
    Duration createEffectDelay = new Duration(.2f);

    public int jumpsCounter { get; private set; }

    private void Awake()
    {
        mana = GetComponent<Mana>();
        rb = GetComponent<Rigidbody2D>();
        grounding = GetComponent<Grounding>();

        if (grounding)
        {
            grounding.onGrounded += ResetJumps;
        }
    }
    public bool CanJump()
    {
        if (mana && !mana.HasAmount(secondJumpManaCost) && jumpsCounter > 0)
            return false;
        if (grounding && !grounding.isGrounded && jumpsCounter == 0)
        {
            return false;
        }
        return jumpsCounter < maxJumps && interval.isDone;
    }
    public void Jump()
    {
        didAddForce = false;
        if (jumpsCounter > 0)
        {
            secondJumpDelay.Start();
            if (mana)
                mana.UseMana(secondJumpManaCost);
        }
        jumpsCounter++;
    }

    public void ResetJumps()
    {
        jumpsCounter = 0;
    }

    private void FixedUpdate()
    {
        if (createEffectDelay.isDoneTrigger)
        {
            Instantiate(jumpEffects[jumpsCounter - 1], transform.position, Quaternion.identity);
        }
        if (!didAddForce && (jumpsCounter == 1 || secondJumpDelay.isDone && jumpsCounter > 1))
        {
            if (jumpEffects.Length > (jumpsCounter - 1) && jumpEffects[jumpsCounter - 1])
                createEffectDelay.StartWithDuration(jumpEffectDelay);
            //create jump effect by jumpsCounter

            rb.velocity = new Vector2(rb.velocity.x, jumpForce * (jumpsCounter == 1 ? 1 : secondJumpMultiplier));
            didAddForce = true;
            interval.Start();
            timeSinceJump = 0;
        }
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