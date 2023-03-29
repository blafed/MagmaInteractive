using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FlyingEye : Unit
{

    public enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Die,
    }
    public float searchInterval = .5f;
    public float maxChasingDistance = 10;
    public float patrolDistance = 5;

    public float speed = 1;
    public float sight => maxChasingDistance;

    public float attackReload = 5;
    public GameObject projectilePrefab;


    Animator animator;




    Rigidbody2D rb;

    Vector2 patrolPosition;


    float movementDir = 1;

    Vector2 startChasingPosition;
    NpcTarget target;
    float searchTimer;
    State state;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
        state = State.Patrol;
    }

    void StartPatrol()
    {
        state = State.Patrol;
        patrolPosition = position;
        movementDir *= -1;
    }
    void StartChase(NpcTarget target)
    {
        startChasingPosition = position;
        this.target = target;
        state = State.Chase;
    }



    void SearchForTarget()
    {
        var colliders = Physics2D.OverlapCircleAll(position, sight);
        foreach (var collider in colliders)
        {
            var target = collider.GetComponent<NpcTarget>();
            if (target)
            {
                StartChase(target);
                break;
            }
        }
    }


    private void FixedUpdate()
    {
        searchTimer -= Time.fixedDeltaTime;
        if (searchTimer <= 0)
        {
            searchTimer = searchInterval;
            SearchForTarget();
        }


        if (state == State.Chase)
        {
            var diff = target.position - position;
            var dir = diff.normalized;
            dir.y = 0;
            rb.velocity = dir * speed;
            if (diff.sqrMagnitude > maxChasingDistance.Squared())
            {
                StartPatrol();
            }
        }
        else if (state == State.Patrol)
        {
            var diff = position - patrolPosition;
            diff.y = 0;
            if (diff.sqrMagnitude > patrolDistance.Squared())
            {
                StartPatrol();
            }
            rb.velocity = Vector2.right * movementDir * speed;
        }
        else if (state == State.Idle)
        {
            rb.velocity = Vector2.zero;
        }
        else if (state == State.Die)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else if (state == State.Attack)
        {

        }
    }

    private void Update()
    {
        PlayAnimation(state.ToString());
    }


    public void PlayAnimation(string name)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(name))
            return;
        animator.Play(name);
    }


    public void Attack()
    {

        var go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        var projectile = go.GetComponent<Projectile>();
        var accelerator = go.GetComponent<AccelerateTowards>();
        accelerator.target = target.transform;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(position, sight);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(position, position + Vector2.right * patrolDistance);
    }

    //
}