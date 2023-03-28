using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5;
    public bool allowVerticalMovement;
    public Vector2 movementInput;

    int velocityIndex;


    public bool isMoving => movementInput.x.Abs() > 0.1f;

    Character character;

    private void Awake()
    {
        character = GetComponentInParent<Character>();
    }
    private void Start()
    {
        velocityIndex = character.AddVelocity();
    }
    private void FixedUpdate()
    {
        if (character.dash != null && character.dash.isDashing)
        {
            character.velocities[velocityIndex] = Vector2.zero;
            return;
        }
        var movementInput = this.movementInput;
        if (!allowVerticalMovement)
            movementInput.y = 0;
        character.velocities[velocityIndex] = movementInput * speed;

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