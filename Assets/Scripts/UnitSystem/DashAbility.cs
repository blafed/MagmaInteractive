using UnityEngine;

public class DashAbility : MonoBehaviour
{
    public float speed = 10f;
    public Duration duration = new Duration(.7f);
    public Duration cooldown = new Duration(2);
    public float powerCost = 40;



    Movement movement;
    Power power;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        power = GetComponentInParent<Power>();
    }

    public bool isDashing => !duration.isDone;

    public bool CanDash()
    {
        return duration.isDone && cooldown.isDone && (!power || power.power.current >= powerCost);
    }
    public void Dash()
    {
        duration.Start();

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            transform.position += transform.right * transform.localScale.x * speed * Time.fixedDeltaTime;
            if (movement)
                movement.inputMovement = Vector2.zero;



        }

        if (duration.isDoneTrigger)
        {
            cooldown.Start();
        }

    }
}