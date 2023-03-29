using System;
using System.Diagnostics.Contracts;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ShooterWeapon : Weapon
{

    protected virtual bool overrideProjectileDamage => true;
    public event Action<Projectile> onShoot;
    public GameObject projectilePrefab;
    [SerializeField] Transform spawner;


    public override void Attack()
    {
        base.Attack();


    }


    public Projectile Shoot()
    {
        var spawner = this.spawner ?? transform;
        var go = Instantiate(projectilePrefab, spawner.position, spawner.rotation);
        var projectile = go.GetComponent<Projectile>();
        if (projectile)
        {
            projectile.owner = owner;
            projectile.weapon = this;
            if (overrideProjectileDamage)
                projectile.damage = damage;
        }
        onShoot?.Invoke(projectile);
        return projectile;
    }
}