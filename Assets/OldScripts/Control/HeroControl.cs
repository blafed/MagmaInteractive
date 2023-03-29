using UnityEngine;

public class HeroControl : MonoBehaviour
{
    public Hero hero { get; private set; }

    private void Awake()
    {
        hero = GetComponentInParent<Hero>();
    }

    void Update()
    {
        var inp = InputManager.instance;
        hero.movement.movementInput = inp.movement;
        if (inp.jump)
            if (hero.jump.CanJump())
                hero.jump.Jump();
        if (inp.attack)
            if (hero.weapon.CanAttack())
                hero.weapon.Attack();
        if (inp.dash)
            if (hero.dash.CanDash())
                hero.dash.Dash();
    }
}