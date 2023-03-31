using UnityEngine;

public class GenericEnemy : Enemy
{

    protected override void OnTargetExist()
    {
        base.OnTargetExist();
        if (canFollow)
            SetFollowTarget(true);
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

    protected override void WhileTargetExist()
    {
        base.WhileTargetExist();
        WeaponTryAttack();
    }




    protected override void Cycle()
    {
        base.Cycle();
    }

}