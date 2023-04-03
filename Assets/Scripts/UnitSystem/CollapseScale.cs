using System.Collections;
using UnityEngine;

public class CollapseScale : MonoBehaviour
{
    new Collider2D collider;
    Rigidbody2D rb;


    AudioSource audioSource;


    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    IEnumerator Start()
    {
        if (audioSource)
            audioSource.Play();
        collider.isTrigger = false;
        rb.gravityScale = 1;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), 1) * 5, ForceMode2D.Impulse);
        while (transform.localScale.x > 0.1f)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, 1 * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }

}