using UnityEngine;

public class AddSpeedAtStart : MonoBehaviour
{
    public float speed = 10;



    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed * rb.mass, ForceMode2D.Impulse);

    }
}