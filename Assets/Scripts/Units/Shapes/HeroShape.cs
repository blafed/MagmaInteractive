using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HeroShape : Shape
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
        Hurt,
        Sprint,
        Land,
    }


    public State state { get; private set; }
    public Hero hero { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        hero = GetComponentInParent<Hero>();
    }

    protected override string GetNewAnimationState()
    {
        string animationState;

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
        if (hero.sprintAbility.isSprinting)
        {
            state = State.Sprint;
        }
        else if (hero.grounding.groundTime < .5f && hero.grounding.isGrounded)
        {
            state = State.Land;
        }

        if (hero.health.takeDamageTimer.elabsed < .5f)
        {
            state = State.Hurt;
        }



        animationState = state.ToString();

        if (state == State.Jump)
        {
            if (hero.jumpAbility.jumpsCounter > 1)
            {
                animationState = "DoubleJump";
            }
        }





        if (hero.weapon && hero.weapon.isAttacking && !string.IsNullOrEmpty(hero.weapon.animationName))
        {
            animationState = hero.weapon.animationName;
        }
        if (hero.health.isKilled)
        {
            animationState = "Die";
        }
        if (hero.hasWin)
            animationState = "Win";

        return animationState;
    }

}