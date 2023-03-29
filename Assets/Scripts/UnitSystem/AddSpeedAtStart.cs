using UnityEngine;

public class AddSpeedAtStart : MonoBehaviour
{
    public float speed = 10;
    public bool impulse;



    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (impulse)
        {
            rb.AddForce(transform.right * speed * rb.mass, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.right * speed * rb.mass, ForceMode2D.Force);
        }

    }
}