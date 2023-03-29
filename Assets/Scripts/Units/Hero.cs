using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public static Hero current { get; private set; }
    public bool controllable = true;
    public Grounding grounding { get; private set; }
    public Health health { get; private set; }
    public JumpAbility jumpAbility { get; private set; }
    public Movement movement { get; private set; }
    public DashAbility dashAbility { get; private set; }
    public Power power { get; private set; }

    public Weapon weapon;






    public List<Key> keys = new List<Key>();




    private void Awake()
    {
        if (!current)
        {
            current = this;
        }
        health = GetComponent<Health>();
        jumpAbility = GetComponent<JumpAbility>();
        movement = GetComponent<Movement>();
        dashAbility = GetComponent<DashAbility>();
        power = GetComponent<Power>();
        grounding = GetComponent<Grounding>();

    }


    private void Update()
    {
        if (controllable)
        {
            if (InputManager.instance.jump)
            {
                if (jumpAbility.CanJump())
                    jumpAbility.Jump();
            }
            if (InputManager.instance.dash)
            {
                if (dashAbility.CanDash())
                    dashAbility.Dash();
            }
            if (InputManager.instance.attack)
            {
                if (weapon && weapon.CanAttack())
                {
                    weapon.Attack();
                }
            }
            var inputMovement = InputManager.instance.movement;
            movement.inputMovement = inputMovement.normalized;

        }
    }



}