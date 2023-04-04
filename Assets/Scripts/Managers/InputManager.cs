using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 movement;
    public bool attack;
    public bool jump;
    public bool dash;
    public bool chargedAttack;
    public bool ultimateAttack;
    public bool sprint;


    private void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        attack = Input.GetButton("Fire1");
        jump = Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical");
        dash = Input.GetButtonDown("Dash");
        sprint = Input.GetButton("Sprint");

        chargedAttack = Input.GetButton("Fire2");
        ultimateAttack = Input.GetButtonDown("Fire3");
    }
}