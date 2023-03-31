using UnityEngine;

public class SpellWeapon : ShooterWeapon
{
    [Space]
    public LayerMask targetLayer = -1;
    // SpellTarget FindTarget()
    // {
    //     SpellTarget current = null;
    //     var dst = 0;

    //     foreach (var x in GameLevel.current.spellTargets)
    //     {
    //         if ((targetLayer & (1 << x.gameObject.layer)) == 0)
    //             continue;
    //         //skip dead
    //         if (x.health && x.health.isKilled)
    //             continue;
    //         //skip out of range
    //         var closestPointOnBounds = x.rect.ClampPoint(x.rect.center);
    //         var xDst = (closestPointOnBounds - (Vector2)transform.position).sqrMagnitude;
    //         if (xDst > range.Squared())
    //             continue;

    //         if (!current || x.priority > current.priority || x.priority == current.priority && xDst < dst)
    //             current = x;
    //     }
    //     return current;
    // }
    Health FindTarget()
    {
        Health current = null;
        var dst = 0;

        foreach (var x in GameLevel.current.healths)
        {
            if ((targetLayer & (1 << x.gameObject.layer)) == 0)
                continue;
            //skip dead
            if (x && x.isKilled)
                continue;
            //skip out of range
            var closestPointOnBounds = (Vector2)x.transform.position; //x.rect.ClampPoint(x.rect.center);
            var xDst = (closestPointOnBounds - (Vector2)transform.position).sqrMagnitude;
            if (xDst > range.Squared())
                continue;

            if (!current || x.priority > current.priority || x.priority == current.priority && xDst < dst)
                current = x;
        }
        return current;
    }


    public override bool CanAttack()
    {
        return base.CanAttack() && FindTarget() != null;
    }

    public override void Attack()
    {
        var target = FindTarget();
        if (target != null)
        {
            base.Attack();
        }
    }

    protected override GameObject SpawnProjectile()
    {
        var proj = base.SpawnProjectile();
        proj.transform.position = FindTarget().transform.position;
        return proj;
    }
}