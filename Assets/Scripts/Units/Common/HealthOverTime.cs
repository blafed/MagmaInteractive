namespace Mend
{
    using UnityEngine;

    public class HealthOverTime : MonoBehaviour
    {
        public Health health { get; private set; }

        [Tooltip("The amount of health to be added or removed per minute.")]
        public float rate = 20;
        public bool stepped;
        public float stepInterval = .5f;

        private void Awake()
        {
            health = GetComponentInParent<Health>();
        }

        private void FixedUpdate()
        {
            if (stepped)
            {
                if (Time.frameCount % (stepInterval / Time.fixedDeltaTime) == 0)
                    health.AddHp(rate * stepInterval / 60);
            }
            else
                health.AddHp(rate * Time.fixedDeltaTime / 60);
        }
    }
}