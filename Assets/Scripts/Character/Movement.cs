namespace MagmaInteractive.Abilities
{
    using UnityEngine;

    [AddComponentMenu("Character/Movement")]
    public class Movement : MonoBehaviour
    {
        public float speed = 5;
        [Range(0, 1)]
        public float movementScale = 0;


        Character character;

        private void Awake()
        {
            character = GetComponentInParent<Character>();
        }

        private void FixedUpdate()
        {
            if (!character.isGrounded)
                return;
            //Limit to maximum speed
            if (character.rb.velocity.sqrMagnitude >= speed.Squared())
                return;
            if (movementScale > 0)
            {
                character.animator.SetSpeed(speed);
                character.animator.SetState(CharacterAnimation.Jump);
                character.rb.AddForce(speed * Vector2.right * Character.LookDirectionToScale(character.lookDirection) * movementScale);
            }

        }
    }
}