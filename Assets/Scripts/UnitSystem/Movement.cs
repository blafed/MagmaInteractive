using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMoving => inputMovement.sqrMagnitude > 0.001f;
    public float speed = 4f;
    public Vector2 inputMovement;
    public bool allowVerticalMovement = false;


    Vector3 originScale;
    IWeaponHolder weaponHolder;

    private void Awake()
    {
        originScale = transform.localScale;
        weaponHolder = GetComponent<IWeaponHolder>();
    }


    private void FixedUpdate()
    {
        var movement = new Vector2(inputMovement.x, allowVerticalMovement ? inputMovement.y : 0);
        transform.position += (Vector3)movement * speed * Time.fixedDeltaTime;

        // if (weaponHolder == null || weaponHolder.weapon == null || !weaponHolder.weapon.isAttacking)
        {
            if (inputMovement.x < -.001f)
            {
                transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), originScale);
            }
            else if (inputMovement.x > 0.001f)
            {
                transform.localScale = originScale;
            }
        }
    }


}