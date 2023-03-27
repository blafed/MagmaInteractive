using UnityEngine;

namespace Mend
{
    public class CharacterJump : MonoBehaviour
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
        public Character character { get; private set; }


        bool wasGrounded;

        Vector2 velocity
        {
            get => character.velocities[velocityIndex];
            set => character.velocities[velocityIndex] = value;
        }


        private void Awake()
        {
            character = GetComponentInParent<Character>();


        }

        private void Start()
        {

            velocityIndex = character.AddVelocity();
            jumpTime = this.reactivationTime;
        }


        private void FixedUpdate()
        {
            if (isJumping)
                jumpTime += Time.fixedDeltaTime;
            if (character.isGrounded && jumpTime > regroundThreshold)
            {
                jumpCounter = 0;
            }
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, character.effectiveGravity.magnitude * Time.fixedDeltaTime);
            if (!wasGrounded && character.isGrounded)
            {
                Land();
            }
            wasGrounded = character.isGrounded;
        }

        void Land()
        {
            jumpTime = 0;
            jumpCounter = 0;
        }

        public bool CanJump()
        {
            if (jumpTime < reactivationTime)
                return false;
            if (jumpCounter >= maxJumps)
                return false;
            if (!character.isGrounded && jumpCounter == 0)
                return false;

            return true;
        }

        public void Jump()
        {

            character.gravityVelocity = Vector2.zero;

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