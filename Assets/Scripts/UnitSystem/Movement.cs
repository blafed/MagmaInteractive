using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 inputMovement;
    public bool allowVerticalMovement = false;


    Vector3 originScale;

    private void Awake()
    {
        originScale = transform.localScale;
    }


    private void FixedUpdate()
    {
        var movement = new Vector2(inputMovement.x, allowVerticalMovement ? inputMovement.y : 0);
        transform.position += (Vector3)movement * speed * Time.fixedDeltaTime;

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