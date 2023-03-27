namespace Mend
{
    using UnityEngine;

    public class HeroMovement : MonoBehaviour
    {
        public float speed = 5;
        public bool allowVerticalMovement;
        public Vector2 movementInput;

        int velocityIndex;


        public bool isMoving => movementInput.x.Abs() > 0.1f;

        Hero hero;

        private void Awake()
        {
            hero = GetComponentInParent<Hero>();
        }
        private void Start()
        {
            velocityIndex = hero.AddVelocity();
        }
        private void FixedUpdate()
        {
            if (hero.dash != null && hero.dash.isDashing)
            {
                hero.velocities[velocityIndex] = Vector2.zero;
                return;
            }
            var movementInput = this.movementInput;
            if (!allowVerticalMovement)
                movementInput.y = 0;
            hero.velocities[velocityIndex] = movementInput * speed;

            if (movementInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movementInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}