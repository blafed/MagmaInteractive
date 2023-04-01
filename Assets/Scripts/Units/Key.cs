using System.Collections;
using UnityEngine;


public class Key : MonoBehaviour
{
    public GameObject effectPrefab;

    Rigidbody2D rb;
    new Collider2D collider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var hero = other.GetComponentInParent<Hero>();
        if (hero)
        {
            hero.keys.Add(this);
            if (effectPrefab != null)
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
            GetComponent<CollapseScale>().enabled = true;
        }
    }
}