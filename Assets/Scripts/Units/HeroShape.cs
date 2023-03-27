using UnityEngine;

namespace Mend
{
    public class HeroShape : MonoBehaviour
    {
        public Animator animator { get; private set; }
        public SpriteRenderer spriteRenderer { get; private set; }

        Hero hero;
        HeroAnimationState animationState;



        public HeroAnimationState weaponAnimationState { get; set; }


        private void Awake()
        {
            hero = GetComponentInParent<Hero>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animationState = HeroAnimationState.Idle;
            if (hero.isGrounded)
            {
                if (hero.movement.isMoving)
                {
                    animationState = HeroAnimationState.Run;
                }
                else
                {
                    animationState = HeroAnimationState.Idle;
                }
            }
            else if (hero.isFalling)
            {
                animationState = HeroAnimationState.Fall;
            }
            else if (hero.jump.isJumping)
            {
                animationState = HeroAnimationState.Jump;
            }

            if (weaponAnimationState != HeroAnimationState.Unset)
            {
                animationState = weaponAnimationState;
            }

            if (hero.health.isKilled)
            {
                animationState = HeroAnimationState.Die;
            }






            PlayAnimation(animationState.ToString());

        }




        public void PlayAnimation(string name)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(name))
                return;
            animator.Play(name);
        }

    }


    public enum HeroAnimationState
    {
        Unset,
        Idle,
        Run,
        Jump,
        Fall,
        Die,
        Attack1,
        Attack2,
        Attack3,
    }
}