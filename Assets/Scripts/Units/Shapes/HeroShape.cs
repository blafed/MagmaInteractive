using System.Collections.Generic;
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

    [System.Serializable]
    public class AnimationInfo
    {
        public string name;
        public Vector2 pivot;
        public float duration;
        public int priority;
    }


    public State state { get; private set; }

    public Animator animator { get; private set; }
    public Hero hero { get; private set; }
    public SpriteRenderer renderer { get; private set; }

    public string animationState { get; set; }
    public string customAnimation { get; set; }
    public Duration playAnimationDuration = new Duration(1);


    public List<AnimationInfo> animationInfos = new List<AnimationInfo>();

    string oldAnimationState;
    Vector2 originalPivot;

    int animationPirority = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hero = GetComponentInParent<Hero>();
        renderer = GetComponent<SpriteRenderer>();
        originalPivot = transform.localPosition;
    }

    void Update()
    {
        oldAnimationState = this.animationState;
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


        animationState = state.ToString();

        if (state == State.Jump)
        {
            if (hero.jumpAbility.jumpsCounter > 1)
            {
                this.animationState = "DoubleJump";
            }
        }



        if (hero.weapon && hero.weapon.isAttacking && !string.IsNullOrEmpty(hero.weapon.animationName))
        {
            animationState = hero.weapon.animationName;
        }

        var newPriority = 0;

        foreach (var x in animationInfos)
        {
            if (x.name == animationState)
                newPriority = x.priority;
        }



        if (playAnimationDuration.isDone || newPriority >= animationPirority)
        {
            if (!IsAnimationPlaying(animationState))
            {
                SetAnimation(animationState);

                transform.localPosition = originalPivot;
                animationPirority = 0;
                foreach (var x in animationInfos)
                {
                    if (x.name == animationState)
                    {
                        transform.localPosition = originalPivot + x.pivot;
                        playAnimationDuration.StartWithDuration(x.duration);
                        animationPirority = x.priority;
                    }
                }
            }
        }
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