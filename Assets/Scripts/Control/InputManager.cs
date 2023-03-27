namespace Mend
{
    using UnityEngine;

    public class InputManager : Singleton<InputManager>
    {
        public Vector2 movement;
        public bool attack;
        public bool jump;
        public bool dash;

        private void Update()
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            attack = Input.GetButton("Fire1");
            jump = Input.GetButtonDown("Jump");
            dash = Input.GetButtonDown("Dash");
        }
    }
}