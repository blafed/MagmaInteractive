using UnityEngine;

namespace MagmaInteractive.Abilities
{
    [AddComponentMenu("Character/Jump")]
    public class Jump : MonoBehaviour
    {
        public float activationTime = 1;
        public float height = 5;
        Character character;
        Rigidbody2D rb;


        float timer;

        private void Awake()
        {
            rb = GetComponentInParent<Rigidbody2D>();
            character = GetComponentInParent<Character>();
        }


        public bool CanJump()
        {
            return character.isGrounded && Time.time > timer + activationTime;
        }
        public void ForceJump()
        {
            character.rb.AddForce(height * Vector2.up);
        }
        public bool TryJump()
        {
            if (!CanJump())
                return false;
            ForceJump();
            timer = Time.time;
            return true;
        }
    }
}