using System.Collections.Generic;
using UnityEngine;

namespace Mend
{
    public class MeleeWeapon : Weapon
    {
        public float delay = .5f;
        public float activationTime = .1f;

        public override bool isAttacking => _isAttacking;
        bool _isAttacking;


        [SerializeField] Collider2D[] colliders;
        [SerializeField] CreateEffectOptions effect;

        float delayTimer;
        float activeTimer;


        List<Health> hit = new List<Health>();

        public override void Attack()
        {
            base.Attack();
            _isAttacking = true;
            delayTimer = 0;
            activeTimer = 0;
            if (effect)
                effect.Create(transform);
        }
        public override bool CanAttack()
        {
            return base.CanAttack() && !isAttacking;
        }


        private void Start()
        {
            colliders.ForEach(x => x.enabled = false);
        }

        private void FixedUpdate()
        {
            colliders.ForEach(x => x.enabled = (isAttacking && activeTimer < activationTime && delayTimer >= delay));
            if (activeTimer > activationTime)
                _isAttacking = false;

            if (isAttacking)
            {
                if (delayTimer < delay)
                {
                    delayTimer += Time.fixedDeltaTime;
                }
                else
                {
                    activeTimer += Time.fixedDeltaTime;
                    colliders.ForEach(x => x.enabled = true);
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            Health health;
            if (health = other.GetComponent<Health>())
            {
                other.GetComponent<Health>().TakeDamage(damage, this);
            }
        }

    }
}