using Codice.Client.Commands.TransformerRule;
using UnityEngine;

public class ShooterWeapon : Weapon
{
    bool _isAttacking = false;
    public override bool isAttacking => _isAttacking;

    public GameObject projectilePrefab;
    public GameObject effectPrefab;

    public Duration delay = new Duration(.3f);
    public Duration reload = new Duration(1);
    public float damage = 20;
    public float range = 10;
    public float projectileSpeed = 10;
    public float projetileLifeTime = .5f;



    public override bool CanAttack() => delay.isDone && reload.isDone;
    public override void Attack()
    {
        _isAttacking = true;
        delay.Start();
    }

    void SpawnProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        if (effectPrefab)
            Instantiate(effectPrefab, transform.position, transform.rotation);

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
            limitLifetime.lifeTime.duration = projetileLifeTime;
        }
    }


    private void FixedUpdate()
    {
        if (isAttacking && delay.isDone)
        {
            SpawnProjectile();
            reload.Start();
            _isAttacking = false;
        }
    }


}