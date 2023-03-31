using UnityEngine;

public class BasicWeapon : GenericWeapon
{
    protected bool _isAttacking;
    public override bool isAttacking => _isAttacking;

    public GameObject effectPrefab;
    public bool parentEffectToThis = true;

    public float postAttackTime = .5f;

    bool didAttack = false;

    public override bool CanAttack() => delay.isDone && reload.isDone;
    public override void Attack()
    {
        _isAttacking = true;
        didAttack = false;
        delay.Start();
        reload.Start();
    }

    protected virtual void ActualAttack()
    {
        if (effectPrefab)
        {
            var eff = Instantiate(effectPrefab, transform.position, transform.rotation);
            var originalScale = eff.transform.localScale;
            if (parentEffectToThis)
            {
                eff.transform.SetParent(transform);
                eff.transform.localScale = originalScale;
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if (isAttacking && delay.isDone)
        {
            if (!didAttack)
            {
                ActualAttack();
                reload.Start();
                didAttack = true;
            }
            if (delay.postElabsed > postAttackTime)
                _isAttacking = false;
        }
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}