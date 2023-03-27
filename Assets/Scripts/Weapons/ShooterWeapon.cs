namespace Mend
{
    using System.Diagnostics.Contracts;
    using UnityEngine;

    public class ShooterWeapon : Weapon
    {
        public float delay;
        public GameObject projectilePrefab;
        [SerializeField] Transform spawner;

        public override bool isAttacking => Time.time < reloadTimer + delay;





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
            }
            return projectile;
        }
    }
}