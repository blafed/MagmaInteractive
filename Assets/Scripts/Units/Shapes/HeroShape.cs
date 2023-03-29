using System.Threading.Tasks;
using UnityEngine;

public class HeroShape : MonoBehaviour
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Die,
        Dash,
        Jump,
        Fall,
        Hit,
        Stun,

    }


    public State state { get; private set; }

    public Animator animator { get; private set; }
    public Hero hero { get; private set; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        hero = GetComponentInParent<Hero>();
    }

    void Update()
    {
        if (hero.dashAbility.isDashing)
        {
            state = State.Dash;
        }
        else
        if (hero.jumpAbility.isJumping)
        {
            state = State.Jump;
        }
        else if (hero.grounding.isFalling)
        {
            state = State.Fall;
        }
        else
        if (hero.movement.isMoving)
        {
            state = State.Run;
        }
        else
        {
            state = State.Idle;
        }




        var stateName = state.ToString();
        if (hero.weapon && hero.weapon.isAttacking && !string.IsNullOrEmpty(hero.weapon.animationName))
        {
            stateName = hero.weapon.animationName;
        }
        if (!IsAnimationPlaying(stateName))
            SetAnimation(stateName);
    }

    public bool IsAnimationPlaying(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }
    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}