using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 movement;
    public bool attack;
    public bool jump;
    public bool dash;
    public bool chargedAttack;
    public bool ultimateAttack;


    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        attack = Input.GetButton("Fire1");
        jump = Input.GetButtonDown("Jump");
        dash = Input.GetButtonDown("Dash");

        chargedAttack = Input.GetButton("Fire2");
        ultimateAttack = Input.GetButtonDown("Fire3");
    }
}