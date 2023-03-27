namespace Mend
{
    using UnityEngine;

    public class HeroDash : MonoBehaviour
    {
        public float powerCost = .1f;
        public float speed = 5;
        public float duration = .5f;
        public float cooldown = .5f;

        float dashTimer;
        float cooldownTimer;

        Hero hero;

        int velocityIndex;


        [SerializeField] GameObject effectObject;
        [SerializeField] GameObject effectPrefab;



        GameObject effectInstance;


        public bool isDashing => dashTimer > 0;


        private void Start()
        {
            hero = GetComponentInParent<Hero>();
            velocityIndex = hero.AddVelocity();
        }

        public bool CanDash()
        {
            return hero.power.power >= powerCost && dashTimer <= 0 && cooldownTimer <= 0;
        }
        public void Dash()
        {
            var go = effectInstance = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            go.transform.parent = transform;
            dashTimer = duration;
            cooldownTimer = cooldown;
            hero.power.UsePower(powerCost);
        }

        public void Stop()
        {
            dashTimer = 0;
        }


        void FixedUpdate()
        {
            if (dashTimer > 0)
            {
                dashTimer -= Time.fixedDeltaTime;
                hero.velocities[velocityIndex] = transform.right * hero.transform.localScale.x * speed;
            }
            else
            {
                cooldownTimer = Mathf.MoveTowards(cooldownTimer, 0, Time.fixedDeltaTime);
                hero.velocities[velocityIndex] = Vector2.zero;
                dashTimer = Mathf.MoveTowards(dashTimer, 0, Time.fixedDeltaTime);
                if (effectInstance)
                    Destroy(effectInstance);
            }
            effectObject.SetActive(isDashing);
        }
    }
}