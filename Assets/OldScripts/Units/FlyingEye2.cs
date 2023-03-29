using System;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingEye2 : Unit
{
    NpcPatrol patrol;
    NpcSight sight;
    NpcFollow follow;
    Rigidbody2D rb;
    ShooterWeapon weapon;



    protected override void Awake()
    {
        base.Awake();
        patrol = GetComponent<NpcPatrol>();
        sight = GetComponent<NpcSight>();
        follow = GetComponent<NpcFollow>();
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<ShooterWeapon>();
    }

    private void Start()
    {
        sight.onTargetFound += OnTargetFound;
        sight.onTargetLost += OnTargetLost;
        health.onKilled += OnKilled;
        weapon.onShoot += OnShoot;
    }

    private void OnShoot(Projectile obj)
    {
        obj.GetComponent<AccelerateTowards>().target = follow.target;
    }

    private void FixedUpdate()
    {
        if (follow.target)
        {
            if (weapon.CanAttack())
                weapon.Attack();
        }
    }



    private void OnTargetFound(NpcTarget target)
    {
        patrol.enabled = false;
        follow.enabled = true;
        follow.target = target.transform;

    }

    private void OnTargetLost(NpcTarget target)
    {
        patrol.enabled = true;
        follow.enabled = false;
        follow.target = null;
    }

    private void OnKilled()
    {
        patrol.enabled = false;
        follow.enabled = false;
        sight.enabled = false;
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}