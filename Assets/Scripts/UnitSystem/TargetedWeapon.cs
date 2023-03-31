using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TargetedWeapon : BasicWeapon
{
    public Health target { get; set; }

    public override bool isAttacking => target && base.isAttacking;

    public override bool CanAttack()
    {
        return base.CanAttack() && target;
    }
    protected override void ActualAttack()
    {
        base.ActualAttack();
        if (target)
        {
            target.TakeDamage(damage);
        }
    }

    public override void SetTarget(Health target)
    {
        this.target = target;
    }

}