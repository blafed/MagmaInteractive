using Codice.Client.Commands.TransformerRule;
using UnityEngine;

public class ShooterWeapon : Weapon
{

    [SerializeField] string _animationName = "Attack";
    bool _isAttacking = false;
    public override string animationName => _animationName;
    public override bool isAttacking => _isAttacking;
    public int projectileDeltaLAyer => 2;

    public GameObject projectilePrefab;
    public GameObject effectPrefab;
    public bool parentEffectToThis = true;

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
        reload.Start();
    }

    void SpawnProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
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
            limitLifetime.lifeTime.duration = projetileLifeTime;
        }

        projectile.SetLayerRecrusive(gameObject.layer + projectileDeltaLAyer);
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