namespace Mend
{
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
            hero.movement.movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (Input.GetKeyDown(KeyCode.Space))
                hero.jump.Jump();
            if (Input.GetButton("Fire1"))
                if (hero.weapon.CanAttack())
                    hero.weapon.Attack();
            if (Input.GetButtonDown("Dash"))
            {
                if (hero.dash.CanDash())
                    hero.dash.Dash();
            }
        }
    }
}