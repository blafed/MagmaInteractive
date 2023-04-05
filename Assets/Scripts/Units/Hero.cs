using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, IWeaponHolder
{
    public static Hero current { get; private set; }
    public bool controllable = true;
    public Grounding grounding { get; private set; }
    public Health health { get; private set; }
    public Mana mana { get; private set; }
    public JumpAbility jumpAbility { get; private set; }
    public Movement movement { get; private set; }
    public DashAbility dashAbility { get; private set; }
    public SprintAbility sprintAbility { get; private set; }


    public int collectedCoins { get; set; }

    public bool hasWin { get; set; }
    public Weapon weapon { get; private set; }
    [SerializeField] public Weapon defaultWeapon;
    [SerializeField] public Weapon chargedWeapon;
    [SerializeField] public Weapon ultimateWeapon;

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
        grounding = GetComponent<Grounding>();
        mana = GetComponent<Mana>();
        sprintAbility = GetComponentInChildren<SprintAbility>();


        health.onKilled += () =>
        {
            grounding.rb.velocity = new Vector2();
            movement.inputMovement = new Vector2();
        };


    }


    private void Update()
    {
        if (health.isKilled)
        {

            return;
        }
        var inp = InputManager.instance;
        if (controllable)
        {
            if (dashAbility.isDashing)
                return;
            if (inp.jump)
            {
                if (jumpAbility.CanJump())
                    jumpAbility.Jump();
            }
            if (inp.dash)
            {
                if (dashAbility.CanDash())
                    dashAbility.Dash();
            }

            bool doAttack = inp.attack;

            //assign weapon
            if (!weapon || !weapon.isAttacking)
            {
                if (inp.chargedAttack)
                {
                    if (chargedWeapon && chargedWeapon.CanAttack())
                    {
                        weapon = chargedWeapon;
                        doAttack = true;
                    }
                }
                else if (inp.ultimateAttack)
                {
                    if (ultimateWeapon && ultimateWeapon.CanAttack())
                    {
                        weapon = ultimateWeapon;
                        doAttack = true;
                    }
                }
                else
                {
                    weapon = defaultWeapon;
                }
            }

            if (doAttack)
            {
                if (weapon && weapon.CanAttack())
                {
                    weapon.Attack();
                }
            }

            var inputMovement = inp.movement;
            if (inp.sprint && sprintAbility.CanSprint() && inputMovement.x != 0)
            {
                sprintAbility.SetSprinting(true);
            }
            else
            {
                sprintAbility.SetSprinting(false);
            }
            movement.inputMovement = inputMovement.normalized;

        }
    }



}