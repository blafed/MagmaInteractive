using UnityEngine;

public class GenericEnemy : Enemy
{

    protected override void OnTargetExist()
    {
        base.OnTargetExist();
        if (canFollow)
            SetFollowTarget(true);
        initialAttackDelay.Start();

    }

    protected override void OnTargetLost()
    {
        base.OnTargetLost();

        if (canPatrol)
        {
            SetPatrol(true);
        }
        if (canFollow)
        {
            SetFollowTarget(false);
        }
    }

    protected override void OnTakeDamage(float amount)
    {
        base.OnTakeDamage(amount);

        if (health.damageSender != null)
        {
            if (health.damageSender is Health sender)
            {
                SelectTarget(sender);
            }
        }
    }

    protected override void WhileTargetExist()
    {
        if (health.isKilled)
            return;
        base.WhileTargetExist();
        WeaponTryAttack();
    }




    protected override void Cycle()
    {
        base.Cycle();
    }

}