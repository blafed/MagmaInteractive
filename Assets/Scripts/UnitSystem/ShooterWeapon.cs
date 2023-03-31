using Codice.Client.Commands.TransformerRule;
using Unity.Plastic.Antlr3.Runtime.Tree;
using UnityEngine;

public class ShooterWeapon : Weapon
{

    bool _isAttacking;
    public override bool isAttacking => _isAttacking;
    public int projectileDeltaLAyer => 2;

    public GameObject projectilePrefab;
    public GameObject effectPrefab;
    public bool parentEffectToThis = true;

    public Duration delay = new Duration(.3f);
    public Duration reload = new Duration(1);
    public float postAttackTime = .5f;
    public float damage = 20;
    public float range = 10;
    public float projectileSpeed = 10;
    public float projetileLifeTime = .5f;


    bool didAttack = false;

    public override bool CanAttack() => delay.isDone && reload.isDone;
    public override void Attack()
    {
        _isAttacking = true;
        didAttack = false;
        delay.Start();
        reload.Start();
    }

    protected virtual GameObject SpawnProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.transform.right = Vector3.Scale(transform.right, transform.lossyScale);
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

        var addForceAtStart = projectile.GetComponent<AddSpeedAtStart>();
        if (addForceAtStart)
        {
            addForceAtStart.speed = projectileSpeed;
        }
        var damageTrigger = projectile.GetComponent<DamageTrigger>();
        if (damageTrigger)
        {
            damageTrigger.damage = damage;
        }
        var limitRange = projectile.GetComponent<LimitRange>();
        if (limitRange)
        {
            limitRange.range = range;
        }
        var limitLifetime = projectile.GetComponent<LimitLifetime>();
        if (limitLifetime)
        {
            limitLifetime.lifeTime.value = projetileLifeTime;
        }

        projectile.SetLayerRecrusive(gameObject.layer + projectileDeltaLAyer);

        return projectile;
    }


    private void FixedUpdate()
    {
        if (isAttacking && delay.isDone)
        {
            if (!didAttack)
            {
                SpawnProjectile();
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