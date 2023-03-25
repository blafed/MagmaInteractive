using UnityEngine;

namespace MagmaInteractive
{

    [AddComponentMenu("Character/Character")]
    public class Character : MonoBehaviour
    {
        public Vector2 position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Rigidbody2D rb { get; private set; }
        public new CapsuleCollider2D collider { get; private set; }

        public LookDirection lookDirection
        {
            get => _lookDirection;
        }
        LookDirection _lookDirection;


        public bool isGrounded { get; private set; }
        public CharacterAnimator animator { get; private set; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<CapsuleCollider2D>();
            animator = GetComponent<CharacterAnimator>();
        }


        private void FixedUpdate()
        {
            isGrounded = Physics2D.Raycast(position + Vector2.up * .1f, Vector2.down, .2f);
        }

        public static float LookDirectionToScale(LookDirection dir)
        {
            return dir switch
            {
                LookDirection.Right => 1,
                LookDirection.Left => -1,
                _ => throw new System.Exception()
            };
        }


    }

    public enum LookDirection
    {
        Right,
        Left,
    }

    public enum CharacterAnimation
    {
        Idle,
        Walk,
        Jump,
    }
}
