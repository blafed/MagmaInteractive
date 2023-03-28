using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : Unit
{
    public float gravityScale = 1;
    public LayerMask groundLayerMask;
    [SerializeField] float groundThreshold = .1f;
    [Space]
    public float jumpReactivation = 0;
    public float attackReload = .5f;
    public int maxJumpCount = 2;

    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }
    public Power power { get; private set; }
    public CharacterMovement movement { get; private set; }
    public CharacterJump jump { get; private set; }
    public CharacterDash dash { get; private set; }
    public CharacterShape shape { get; private set; }
    public HeroControl control { get; private set; }
    public bool isGrounded { get; private set; }
    public bool isFalling => rb.velocity.y < 0;
    public float airTime { get; private set; }

    public Weapon weapon { get; private set; }
    public ComboAttack comboAttack { get; private set; }

    public List<Vector2> velocities { get; private set; } = new List<Vector2>();

    public Vector2 effectiveGravity => Physics2D.gravity * gravityScale;


    private Rigidbody2D rb;
    new CapsuleCollider2D collider;

    int gravityVelocityIndex;


    public Vector2 gravityVelocity
    {
        get => velocities[gravityVelocityIndex];
        set => velocities[gravityVelocityIndex] = value;
    }


    [SerializeField] Weapon initialWeapon;


    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        jump = GetComponentInChildren<CharacterJump>();
        shape = GetComponentInChildren<CharacterShape>();
        movement = GetComponentInChildren<CharacterMovement>();
        control = GetComponentInChildren<HeroControl>();
        power = GetComponent<Power>();
        comboAttack = GetComponentInChildren<ComboAttack>();
        dash = GetComponentInChildren<CharacterDash>();

        gravityVelocityIndex = AddVelocity();


    }

    public int AddVelocity()
    {
        velocities.Add(default);
        return velocities.Count - 1;
    }


    private void Start()
    {
        rb.freezeRotation = true;
        weapon = initialWeapon;

    }


    private void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        foreach (var x in velocities)
        {
            rb.velocity += x;
        }
        isGrounded = Physics2D.Raycast(position, Vector2.down, groundThreshold, groundLayerMask)
        | Physics2D.Raycast(position + Vector2.right * collider.size.x * .5f, Vector2.down, groundThreshold, groundLayerMask)
        | Physics2D.Raycast(position - Vector2.right * collider.size.x * .5f, Vector2.down, groundThreshold, groundLayerMask);


        if (isGrounded)
        {
            velocities[gravityVelocityIndex] = Vector2.zero;
            airTime = 0;
        }
        else
        {
            velocities[gravityVelocityIndex] += effectiveGravity * Time.fixedDeltaTime;
            airTime += Time.fixedDeltaTime;
        }

    }
}