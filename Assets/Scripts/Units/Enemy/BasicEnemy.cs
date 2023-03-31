using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Die,
        Patrol,

    }
    public State defaultState;
    protected Sight sight;
    protected State state;
    protected Shape shape;
    protected Weapon weapon;
    protected Health health;
    protected Health target;
    protected Follow follow;

    protected virtual void Awake()
    {
        shape = GetComponentInChildren<Shape>();
        sight = GetComponent<Sight>();
        weapon = GetComponentInChildren<TargetedWeapon>();
        health = GetComponent<Health>();
        follow = GetComponent<Follow>();



        sight.onTargetEnter += OnTargetEnter;
        sight.onTargetExit += OnTargetExit;
        health.onKilled += () =>
        {
            foreach (var x in GetComponentsInChildren<Collider2D>())
            {
                x.enabled = false;
            }
            state = State.Die;
            Destroy(gameObject, 2);
        };
    }

    protected virtual void OnTargetEnter(GameObject target)
    {
        if (this.health.isKilled)
            return;
        if (target)
            return;
        state = State.Run;
        var health = target.GetComponentInParent<Health>();
        if (health)
        {
            weapon.SetTarget(health);
            this.target = health;
        }

    }
    protected virtual void OnTargetExit(GameObject target)
    {
        if (this.health.isKilled)
            return;
        if (this.target == target)
        {
            weapon.SetTarget(null);
            this.target = null;
        }
    }


    private void Update()
    {
        shape.animationState = state.ToString();
        if (weapon.isAttacking)
        {
            state = State.Attack;
        }
        if (!target)
        {
            state = defaultState;
        }
    }

    private void FixedUpdate()
    {
        if (health.isKilled)
            return;

        follow.enabled = target;
        if (target)
        {
            if (follow)
                follow.target = target.transform;
            if (weapon.CanAttack())
            {
                weapon.Attack();
            }
        }
        else
        {
            if (follow)
                follow.target = null;
        }

    }
}