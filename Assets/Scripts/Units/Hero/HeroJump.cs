using UnityEngine;

namespace Mend
{
    public class HeroJump : MonoBehaviour
    {
        public float reactivationTime = 0;
        public int maxJumps = 2;
        public float jumpHeight = 4;
        public float regroundThreshold = 1;

        int velocityIndex;
        float jumpTime;


        [SerializeField]
        GameObject[] jumpEffects;


        public bool isJumping => jumpCounter > 0;

        public int jumpCounter { get; private set; }
        public Hero hero { get; private set; }


        bool wasGrounded;

        Vector2 velocity
        {
            get => hero.velocities[velocityIndex];
            set => hero.velocities[velocityIndex] = value;
        }


        private void Awake()
        {
            hero = GetComponentInParent<Hero>();


        }

        private void Start()
        {

            velocityIndex = hero.AddVelocity();
            jumpTime = this.reactivationTime;
        }


        private void FixedUpdate()
        {
            if (isJumping)
                jumpTime += Time.fixedDeltaTime;
            if (hero.isGrounded && jumpTime > regroundThreshold)
            {
                jumpCounter = 0;
            }
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, hero.effectiveGravity.magnitude * Time.fixedDeltaTime);
            if (!wasGrounded && hero.isGrounded)
            {
                Land();
            }
            wasGrounded = hero.isGrounded;
        }

        void Land()
        {
            jumpTime = 0;
            jumpCounter = 0;
        }

        public void Jump()
        {
            if (jumpTime < reactivationTime)
                return;
            if (jumpCounter >= maxJumps)
                return;
            if (!hero.isGrounded && jumpCounter == 0)
                return;
            hero.gravityVelocity = Vector2.zero;

            if (jumpCounter < jumpEffects.Length)
                if (jumpEffects[jumpCounter])
                    Instantiate(jumpEffects[jumpCounter], transform.position, Quaternion.identity);
                else if (jumpEffects.Length > 0 && jumpEffects[0])
                    Instantiate(jumpEffects[0], transform.position, Quaternion.identity);

            jumpCounter++;


            jumpTime = 0;
            velocity += Vector2.up * Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
        }
    }
}