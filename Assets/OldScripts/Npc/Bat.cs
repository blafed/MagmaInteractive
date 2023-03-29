using UnityEngine;

public class Bat : Unit
{
    public TimerProp formationTime = new TimerProp(.5f);
    public float flyingSpeed = 4;
    public float hitDamage = 15;

    Rigidbody2D rb;


    State state = State.Formation;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        formationTime.Start();
    }

    private void FixedUpdate()
    {
        if (!formationTime.isDone)
            return;
        if (state == State.Fly)
        {
            // rb.velocity = (player.transform.position - transform.position).normalized * flyingSpeed;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<Health>())
        {

        }
    }


    public enum State
    {
        Idle,
        Formation,
        Attack,
        Die,
        Fly,
    }
}