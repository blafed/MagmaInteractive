using Codice.Client.Common.WebApi;
using log4net.Util;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public Duration initialAttackDelay = new Duration(1);
    public Health health { get; private set; }
    protected Shape shape;
    protected Weapon weapon;
    Health target;
    Sight sight;
    Follow follow;
    Patrol patrol;

    Rigidbody2D rb;

    protected bool canPatrol => patrol;
    protected bool canFollow => follow;
    protected bool canSee => sight;


    public bool isSearchingForTarget
    {
        get => sight.enabled;
        set => sight.enabled = value;
    }


    private void Awake()
    {
        health = GetComponent<Health>();
        shape = GetComponentInChildren<Shape>();
        weapon = GetComponentInChildren<Weapon>();
        sight = GetComponent<Sight>();
        follow = GetComponent<Follow>();
        patrol = GetComponent<Patrol>();
        rb = GetComponent<Rigidbody2D>();

        health.onTakeDamage += (amount) =>
        {
            if (health.isKilled)
                return;
            OnTakeDamage(amount);
        };

        health.onKilled += () =>
        {
            if (rb)
                Destroy(rb);
            foreach (var x in GetComponentsInChildren<Collider2D>())
            {
                x.enabled = false;
            }
            if (patrol)
                patrol.enabled = false;
            if (follow)
                follow.enabled = false;
            if (sight)
                sight.enabled = false;
            if (weapon)
                weapon.enabled = false;
            Destroy(gameObject, 3);
        };

        sight.onTargetEnter += (targetGo) =>
        {
            if (health.isKilled)
                return;
            var targetHealth = targetGo.GetComponentInParent<Health>();
            if (targetHealth)
            {
                SelectTarget(targetHealth);
            }

        };
        sight.onTargetExit += (targetGo) =>
        {
            if (health.isKilled)
                return;
            var targetHealth = targetGo.GetComponentInParent<Health>();
            if (targetHealth && targetHealth == target)
            {
                target = null;
                OnTargetLost();
            }
        };
    }


    protected void SelectTarget(Health target)
    {
        if (!target)
        {
            Debug.LogError("Cannot select null target");
            return;
        }
        this.target = target;
        OnTargetExist();
    }

    protected virtual void OnTakeDamage(float amount)
    {

    }
    protected virtual void OnTargetExist() { }
    protected virtual void WhileTargetExist() { }
    protected virtual void OnTargetLost() { }
    protected virtual string GetAnimationState()
    {
        if (health.isKilled)
            return "Die";
        if (weapon && weapon.isAttacking)
            return "Attack";
        if (health && !health.takeDamageTimer.isDone)
            return "Hurt";
        if (follow && follow.enabled || patrol && patrol.enabled && patrol.rest.isDone)
            return "Run";

        return "Idle";
    }



    void FixedUpdate()
    {
        if (target)
            if (target.isKilled)
            {
                target = null;
                OnTargetLost();
            }
        if (target)
            WhileTargetExist();
        Cycle();
        if (shape)
            shape.animationState = (GetAnimationState());
    }

    public void SetPatrol(bool enabled)
    {
        patrol.enabled = enabled;
        if (enabled)
            if (follow)
                follow.enabled = false;
    }
    protected void SetSearching(bool enabled)
    {
        sight.enabled = enabled;
    }

    protected void SetFollowTarget(bool enabled)
    {
        if (enabled)
            follow.target = target.transform;
        follow.enabled = enabled;
        if (enabled)
            if (patrol)
                patrol.enabled = false;
    }
    protected void WeaponTryAttack()
    {
        if (!initialAttackDelay.isDone)
            return;
        weapon.SetTarget(target);
        if (target)
            if (weapon.CanAttack())
                weapon.Attack();
    }


    protected virtual void Cycle()
    {

    }

}