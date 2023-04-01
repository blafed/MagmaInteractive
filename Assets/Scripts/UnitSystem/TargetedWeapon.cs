using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TargetedWeapon : BasicWeapon
{
    public Health target { get; set; }

    public override bool isAttacking => target && base.isAttacking;


    public bool targetInRange => target && Vector2.Distance(transform.position, target.transform.position) < range;

    public override bool CanAttack()
    {
        return base.CanAttack() && target && targetInRange;
    }
    protected override void ActualAttack()
    {
        base.ActualAttack();
        if (target)
        {
            target.TakeDamage(damage, ownerHealth);
        }
    }

    public override void SetTarget(Health target)
    {
        this.target = target;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (target && !targetInRange)
        {
            target = null;
        }
    }

}