
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mend
{
    public class Hero : Unit
    {

        public static Hero current { get; private set; }
        public float gravityScale = 1;
        public LayerMask groundLayerMask;
        [Space]
        public float jumpReactivation = 0;
        public float attackReload = .5f;
        public int maxJumpCount = 2;

        public Vector2 position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Health health { get; private set; }
        public HeroMovement movement { get; private set; }
        public Power power { get; private set; }
        public HeroJump jump { get; private set; }
        public HeroDash dash { get; private set; }
        public HeroShape shape { get; private set; }
        public HeroControl control { get; private set; }
        public bool isGrounded { get; private set; }
        public bool isFalling => rb.velocity.y < 0;
        public float airTime { get; private set; }

        public Weapon weapon { get; private set; }
        public ComboAttack comboAttack { get; private set; }

        public List<Vector2> velocities { get; private set; } = new List<Vector2>();

        public Vector2 effectiveGravity => Physics2D.gravity * gravityScale;


        private Rigidbody2D rb;


        int gravityVelocityIndex;


        public Vector2 gravityVelocity
        {
            get => velocities[gravityVelocityIndex];
            set => velocities[gravityVelocityIndex] = value;
        }


        [SerializeField] Weapon initialWeapon;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            health = GetComponent<Health>();
            jump = GetComponentInChildren<HeroJump>();
            shape = GetComponentInChildren<HeroShape>();
            movement = GetComponentInChildren<HeroMovement>();
            control = GetComponentInChildren<HeroControl>();
            power = GetComponent<Power>();
            comboAttack = GetComponentInChildren<ComboAttack>();
            dash = GetComponentInChildren<HeroDash>();


            gravityVelocityIndex = AddVelocity();

            if (!current)
                current = this;

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
            isGrounded = Physics2D.Raycast(position, Vector2.down, .2f, groundLayerMask);


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

}