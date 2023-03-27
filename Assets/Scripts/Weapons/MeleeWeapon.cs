using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;

namespace Mend
{
    public class MeleeWeapon : Weapon
    {
        public float delay = .5f;
        public float activationTime = .1f;

        public override bool isAttacking => _isAttacking;
        bool _isAttacking;


        [SerializeField] GameObject colliders;
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

            var c = colliders;
            // colliders = Instantiate(c, c.transform.position, c.transform.rotation, c.transform.parent);
            // colliders.name = c.name;
            // Destroy(c);
            interactions.Clear();
        }
        public override bool CanAttack()
        {
            return base.CanAttack() && !isAttacking;
        }


        protected override void Start()
        {
            base.Start();
            // colliders.ForEach(x => x.enabled = false);
            colliders.SetActive(false);
        }

        private void FixedUpdate()
        {
            colliders.SetActive(isAttacking && activeTimer < activationTime && delayTimer >= delay);
            // colliders.ForEach(x => x.enabled = (isAttacking && activeTimer < activationTime && delayTimer >= delay));
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
                    // colliders.ForEach(x => x.enabled = true);
                    colliders.SetActive(true);

                }
            }
        }


        HashSet<Health> interactions = new HashSet<Health>();


        public void OnTriggerEnter2D(Collider2D other)
        {
            Health health;
            if (health = other.GetComponent<Health>())
            {
                if (health == owner.health)
                    return;
                if (interactions.Contains(health))
                    return;
                health.TakeDamage(damage, this);
                interactions.Add(health);
            }
        }

    }
}