using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField] GameObject killEffect;


    void OnTriggerEnter2D(Collider2D other)
    {
        Hero hero;
        if (hero = other.GetComponentInParent<Hero>())
        {
            if (killEffect)
                Instantiate(killEffect, transform.position, Quaternion.identity);
            hero.doorKeys.Enqueue(this);
            Destroy(gameObject);
        }
    }
}